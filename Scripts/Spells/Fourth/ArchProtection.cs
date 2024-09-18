/***************************************************************************
 *
 *   RunUO                   : May 1, 2002
 *   portions copyright      : (C) The RunUO Software Team
 *   email                   : info@runuo.com
 *   
 *   Angel Island UO Shard   : March 25, 2004
 *   portions copyright      : (C) 2004-2024 Tomasello Software LLC.
 *   email                   : luke@tomasello.com
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using Server.Engines.PartySystem;
using Server.Targeting;
using System.Collections;

namespace Server.Spells.Fourth
{
    public class ArchProtectionSpell : Spell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Arch Protection", "Vas Uus Sanct",
                SpellCircle.Fourth,
                Core.RuleSets.AOSRules() ? 239 : 215,
                9011,
                Reagent.Garlic,
                Reagent.Ginseng,
                Reagent.MandrakeRoot,
                Reagent.SulfurousAsh
            );

        public ArchProtectionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(IPoint3D p)
        {
            if (!Caster.CanSee(p))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, p);

                SpellHelper.GetSurfaceTop(ref p);

                ArrayList targets = new ArrayList();

                Map map = Caster.Map;

                if (map != null)
                {
                    IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), Core.RuleSets.AOSRules() ? 2 : 3);

                    foreach (Mobile m in eable)
                    {
                        if (Caster.CanBeBeneficial(m, false))
                            targets.Add(m);
                    }

                    eable.Free();
                }

                if (Core.RuleSets.AOSRules())
                {
                    Party party = Party.Get(Caster);

                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        if (m == Caster || (party != null && party.Contains(m)))
                        {
                            Caster.DoBeneficial(m);
                            Spells.Second.ProtectionSpell.Toggle(Caster, m);
                        }
                    }
                }
                else
                {
                    Effects.PlaySound(p, Caster.Map, 0x299);

                    int val = (int)(Caster.Skills[SkillName.Magery].Value / 10.0 + 1);

                    if (targets.Count > 0)
                    {
                        for (int i = 0; i < targets.Count; ++i)
                        {
                            Mobile m = (Mobile)targets[i];

                            if (m.BeginAction(typeof(ArchProtectionSpell)))
                            {
                                Caster.DoBeneficial(m);
                                m.VirtualArmorMod += val;
                                new InternalTimer(m, Caster, val).Start();

                                m.FixedParticles(0x375A, 9, 20, 5027, EffectLayer.Waist);
                                m.PlaySound(0x1F7);
                            }
                        }
                    }
                }
            }

            FinishSequence();
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Owner;
            private int m_Val;

            public InternalTimer(Mobile target, Mobile caster, int val)
                : base(TimeSpan.FromSeconds(0))
            {
                double time = caster.Skills[SkillName.Magery].Value * 1.2;
                if (time > 144)
                    time = 144;
                Delay = TimeSpan.FromSeconds(time);
                Priority = TimerPriority.OneSecond;

                m_Owner = target;
                m_Val = val;
            }

            protected override void OnTick()
            {
                m_Owner.EndAction(typeof(ArchProtectionSpell));
                m_Owner.VirtualArmorMod -= m_Val;
                if (m_Owner.VirtualArmorMod < 0)
                    m_Owner.VirtualArmorMod = 0;
            }
        }

        private class InternalTarget : Target
        {
            private ArchProtectionSpell m_Owner;

            public InternalTarget(ArchProtectionSpell owner)
                : base(12, true, TargetFlags.None)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                IPoint3D p = o as IPoint3D;

                if (p != null)
                    m_Owner.Target(p);
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
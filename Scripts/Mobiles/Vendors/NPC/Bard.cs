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

using System.Collections;

namespace Server.Mobiles
{
    public class Bard : BaseVendor
    {
        private ArrayList m_SBInfos = new ArrayList();
        protected override ArrayList SBInfos { get { return m_SBInfos; } }

        public override NpcGuild NpcGuild { get { return NpcGuild.BardsGuild; } }

        [Constructable]
        public Bard()
            : base("the bard")
        {
            SetSkill(SkillName.Discordance, 64.0, 100.0);
            SetSkill(SkillName.Musicianship, 64.0, 100.0);
            SetSkill(SkillName.Peacemaking, 65.0, 88.0);
            SetSkill(SkillName.Provocation, 60.0, 83.0);
            SetSkill(SkillName.Archery, 36.0, 68.0);
            SetSkill(SkillName.Swords, 36.0, 68.0);
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBBard());
        }

        public Bard(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
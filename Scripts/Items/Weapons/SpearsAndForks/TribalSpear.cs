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

namespace Server.Items
{
    [FlipableAttribute(0xF62, 0xF63)]
    public class TribalSpear : BaseSpear
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ArmorIgnore; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        //		public override int AosStrengthReq{ get{ return 50; } }
        //		public override int AosMinDamage{ get{ return 13; } }
        //		public override int AosMaxDamage{ get{ return 15; } }
        //		public override int AosSpeed{ get{ return 42; } }
        //
        //		public override int OldMinDamage{ get{ return 2; } }
        //		public override int OldMaxDamage{ get{ return 36; } }
        public override int OldStrengthReq { get { return 30; } }
        public override int OldSpeed { get { return 46; } }

        public override int OldDieRolls { get { return 2; } }
        public override int OldDieMax { get { return 18; } }
        public override int OldAddConstant { get { return 0; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 80; } }

        public override int VirtualDamageBonus { get { return 25; } }

        [Constructable]
        public TribalSpear()
            : base(0xF62)
        {
            Weight = 7.0;
            Hue = 837;
            Name = "a tribal spear";
        }

        public TribalSpear(Serial serial)
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
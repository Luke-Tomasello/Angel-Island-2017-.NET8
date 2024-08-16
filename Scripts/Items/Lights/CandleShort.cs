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
    public class CandleShort : BaseLight
    {
        public override int LitItemID { get { return 0x142C; } }
        public override int UnlitItemID { get { return 0x142F; } }

        [Constructable]
        public CandleShort()
            : base(0x142F)
        {
            if (Burnout)
                Duration = TimeSpan.FromMinutes(25);
            else
                Duration = TimeSpan.Zero;

            Burning = false;
            Light = LightType.Circle150;
            Weight = 1.0;
        }

        public CandleShort(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
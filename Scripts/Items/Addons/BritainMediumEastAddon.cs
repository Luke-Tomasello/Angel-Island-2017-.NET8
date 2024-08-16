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

/*   changelog.
 *   9/16/04,Lego
 *           Changed Display Name of deed 
 *
 *
 *
 */
/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
namespace Server.Items
{
    public class BritainMediumEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new BritainMediumEastAddonDeed();
            }
        }

        public override bool BlocksDoors { get { return false; } }

        [Constructable]
        public BritainMediumEastAddon()
        {
            AddonComponent ac = null;
            ac = new AddonComponent(2765);
            AddComponent(ac, -1, -1, 0);
            ac = new AddonComponent(2759);
            AddComponent(ac, 0, 1, 0);
            ac = new AddonComponent(2759);
            AddComponent(ac, 0, 0, 0);
            ac = new AddonComponent(2759);
            AddComponent(ac, 0, -1, 0);
            ac = new AddonComponent(2765);
            AddComponent(ac, -1, 1, 0);
            ac = new AddonComponent(2765);
            AddComponent(ac, -1, 0, 0);
            ac = new AddonComponent(2762);
            AddComponent(ac, -1, -2, 0);
            ac = new AddonComponent(2766);
            AddComponent(ac, 0, -2, 0);
            ac = new AddonComponent(2759);
            AddComponent(ac, 0, 2, 0);
            ac = new AddonComponent(2763);
            AddComponent(ac, -1, 3, 0);
            ac = new AddonComponent(2765);
            AddComponent(ac, -1, 2, 0);
            ac = new AddonComponent(2768);
            AddComponent(ac, 0, 3, 0);
            ac = new AddonComponent(2759);
            AddComponent(ac, 1, 1, 0);
            ac = new AddonComponent(2759);
            AddComponent(ac, 1, -1, 0);
            ac = new AddonComponent(2767);
            AddComponent(ac, 2, 1, 0);
            ac = new AddonComponent(2767);
            AddComponent(ac, 2, 0, 0);
            ac = new AddonComponent(2767);
            AddComponent(ac, 2, -1, 0);
            ac = new AddonComponent(2766);
            AddComponent(ac, 1, -2, 0);
            ac = new AddonComponent(2764);
            AddComponent(ac, 2, -2, 0);
            ac = new AddonComponent(2759);
            AddComponent(ac, 1, 0, 0);
            ac = new AddonComponent(2759);
            AddComponent(ac, 1, 2, 0);
            ac = new AddonComponent(2761);
            AddComponent(ac, 2, 3, 0);
            ac = new AddonComponent(2767);
            AddComponent(ac, 2, 2, 0);
            ac = new AddonComponent(2768);
            AddComponent(ac, 1, 3, 0);

        }

        public BritainMediumEastAddon(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class BritainMediumEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new BritainMediumEastAddon();
            }
        }

        [Constructable]
        public BritainMediumEastAddonDeed()
        {
            Name = "Britain Medium Carpet [East]";
        }

        public BritainMediumEastAddonDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
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
 *   08/03/06,Rhiannon
 *		Initial creation
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
    public class DisplayCaseSmallEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new DisplayCaseSmallEastAddonDeed();
            }
        }

        [Constructable]
        public DisplayCaseSmallEastAddon()
        {
            AddComponent(new AddonComponent(2725), 0, 1, 5);
            AddComponent(new AddonComponent(2834), 0, 1, 2);
            AddComponent(new AddonComponent(2725), 0, 1, 0);
            AddComponent(new AddonComponent(2721), 0, 0, 5);
            AddComponent(new AddonComponent(2838), 0, 0, 2);
            AddComponent(new AddonComponent(2723), 0, -1, 5);
            AddComponent(new AddonComponent(2832), 0, -1, 2);
            AddComponent(new AddonComponent(2723), 0, -1, 0);
            AddComponent(new AddonComponent(2724), 1, -1, 5);
            AddComponent(new AddonComponent(2835), 1, -1, 2);
            AddComponent(new AddonComponent(2724), 1, -1, 0);
            AddComponent(new AddonComponent(2719), 1, 0, 5);
            AddComponent(new AddonComponent(2836), 1, 0, 2);
            AddComponent(new AddonComponent(2840), 1, 1, 5);
            AddComponent(new AddonComponent(2833), 1, 1, 2);
            AddComponent(new AddonComponent(2840), 1, 1, 0);
            AddonComponent ac = null;
            ac = new AddonComponent(2723);
            AddComponent(ac, 0, -1, 5);
            ac = new AddonComponent(2721);
            AddComponent(ac, 0, 0, 5);
            ac = new AddonComponent(2832);
            AddComponent(ac, 0, -1, 2);
            ac = new AddonComponent(2838);
            AddComponent(ac, 0, 0, 2);
            ac = new AddonComponent(2723);
            AddComponent(ac, 0, -1, 0);

        }

        public DisplayCaseSmallEastAddon(Serial serial)
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

    public class DisplayCaseSmallEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new DisplayCaseSmallEastAddon();
            }
        }

        [Constructable]
        public DisplayCaseSmallEastAddonDeed()
        {
            Name = "small display case (east)";
        }

        public DisplayCaseSmallEastAddonDeed(Serial serial)
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
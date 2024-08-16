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
    public class DisplayCaseLargeSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new DisplayCaseLargeSouthAddonDeed();
            }
        }

        [Constructable]
        public DisplayCaseLargeSouthAddon()
        {
            AddComponent(new AddonComponent(2832), -2, -1, 3);
            AddComponent(new AddonComponent(2723), -2, -1, 6);
            AddComponent(new AddonComponent(2723), -2, -1, 0);
            AddComponent(new AddonComponent(2839), -1, -1, 3);
            AddComponent(new AddonComponent(2722), -1, -1, 6);
            AddComponent(new AddonComponent(2839), 0, -1, 3);
            AddComponent(new AddonComponent(2722), 0, -1, 6);
            AddComponent(new AddonComponent(2839), 1, -1, 3);
            AddComponent(new AddonComponent(2722), 1, -1, 6);
            AddComponent(new AddonComponent(2837), 0, 1, 3);
            AddComponent(new AddonComponent(2720), 0, 1, 6);
            AddComponent(new AddonComponent(2831), 0, 0, 3);
            AddComponent(new AddonComponent(2831), -1, 0, 3);
            AddComponent(new AddonComponent(2837), -1, 1, 3);
            AddComponent(new AddonComponent(2720), -1, 1, 6);
            AddComponent(new AddonComponent(2840), 2, 1, 0);
            AddComponent(new AddonComponent(2833), 2, 1, 3);
            AddComponent(new AddonComponent(2840), 2, 1, 6);
            AddComponent(new AddonComponent(2836), 2, 0, 3);
            AddComponent(new AddonComponent(2719), 2, 0, 6);
            AddComponent(new AddonComponent(2835), 2, -1, 3);
            AddComponent(new AddonComponent(2724), 2, -1, 6);
            AddComponent(new AddonComponent(2724), 2, -1, 0);
            AddComponent(new AddonComponent(2838), -2, 0, 3);
            AddComponent(new AddonComponent(2721), -2, 0, 6);
            AddComponent(new AddonComponent(2831), 1, 0, 3);
            AddComponent(new AddonComponent(2837), 1, 1, 3);
            AddComponent(new AddonComponent(2720), 1, 1, 6);
            AddComponent(new AddonComponent(2725), -2, 1, 0);
            AddComponent(new AddonComponent(2834), -2, 1, 3);
            AddComponent(new AddonComponent(2725), -2, 1, 6);
            AddonComponent ac = null;
            ac = new AddonComponent(2831);
            AddComponent(ac, -1, 0, 3);
            ac = new AddonComponent(2832);
            AddComponent(ac, -2, -1, 3);
            ac = new AddonComponent(2838);
            AddComponent(ac, -2, 0, 3);
            ac = new AddonComponent(2839);
            AddComponent(ac, -1, -1, 3);
            ac = new AddonComponent(2839);
            AddComponent(ac, 0, -1, 3);
            ac = new AddonComponent(2831);
            AddComponent(ac, 0, 0, 3);
            ac = new AddonComponent(2831);
            AddComponent(ac, 1, 0, 3);
            ac = new AddonComponent(2839);
            AddComponent(ac, 1, -1, 3);
            ac = new AddonComponent(2723);
            AddComponent(ac, -2, -1, 6);
            ac = new AddonComponent(2721);
            AddComponent(ac, -2, 0, 6);
            ac = new AddonComponent(2722);
            AddComponent(ac, -1, -1, 6);
            ac = new AddonComponent(2722);
            AddComponent(ac, 0, -1, 6);
            ac = new AddonComponent(2722);
            AddComponent(ac, 1, -1, 6);
            ac = new AddonComponent(2723);
            AddComponent(ac, -2, -1, 0);

        }

        public DisplayCaseLargeSouthAddon(Serial serial)
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

    public class DisplayCaseLargeSouthAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new DisplayCaseLargeSouthAddon();
            }
        }

        [Constructable]
        public DisplayCaseLargeSouthAddonDeed()
        {
            Name = "large display case (south)";
        }

        public DisplayCaseLargeSouthAddonDeed(Serial serial)
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
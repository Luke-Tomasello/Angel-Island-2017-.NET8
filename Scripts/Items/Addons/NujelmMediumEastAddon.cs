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
    public class NujelmMediumEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new NujelmMediumEastAddonDeed();
            }
        }

        public override bool BlocksDoors { get { return false; } }

        [Constructable]
        public NujelmMediumEastAddon()
        {
            AddonComponent ac = null;
            ac = new AddonComponent(2749);
            AddComponent(ac, 0, -1, 0);
            ac = new AddonComponent(2749);
            AddComponent(ac, 0, 0, 0);
            ac = new AddonComponent(2749);
            AddComponent(ac, 0, 1, 0);
            ac = new AddonComponent(2749);
            AddComponent(ac, 0, 2, 0);
            ac = new AddonComponent(2749);
            AddComponent(ac, 1, -1, 0);
            ac = new AddonComponent(2749);
            AddComponent(ac, 1, 0, 0);
            ac = new AddonComponent(2749);
            AddComponent(ac, 1, 1, 0);
            ac = new AddonComponent(2749);
            AddComponent(ac, 1, 2, 0);
            ac = new AddonComponent(2754);
            AddComponent(ac, 2, 3, 0);
            ac = new AddonComponent(2755);
            AddComponent(ac, -1, -2, 0);
            ac = new AddonComponent(2756);
            AddComponent(ac, -1, 3, 0);
            ac = new AddonComponent(2757);
            AddComponent(ac, 2, -2, 0);
            ac = new AddonComponent(2806);
            AddComponent(ac, -1, -1, 0);
            ac = new AddonComponent(2806);
            AddComponent(ac, -1, 0, 0);
            ac = new AddonComponent(2806);
            AddComponent(ac, -1, 1, 0);
            ac = new AddonComponent(2806);
            AddComponent(ac, -1, 2, 0);
            ac = new AddonComponent(2807);
            AddComponent(ac, 0, -2, 0);
            ac = new AddonComponent(2807);
            AddComponent(ac, 1, -2, 0);
            ac = new AddonComponent(2808);
            AddComponent(ac, 2, -1, 0);
            ac = new AddonComponent(2808);
            AddComponent(ac, 2, 0, 0);
            ac = new AddonComponent(2808);
            AddComponent(ac, 2, 1, 0);
            ac = new AddonComponent(2808);
            AddComponent(ac, 2, 2, 0);
            ac = new AddonComponent(2809);
            AddComponent(ac, 0, 3, 0);
            ac = new AddonComponent(2809);
            AddComponent(ac, 1, 3, 0);

        }

        public NujelmMediumEastAddon(Serial serial)
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

    public class NujelmMediumEastAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new NujelmMediumEastAddon();
            }
        }

        [Constructable]
        public NujelmMediumEastAddonDeed()
        {
            Name = "Nujelm Medium Carpet [East]";
        }

        public NujelmMediumEastAddonDeed(Serial serial)
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
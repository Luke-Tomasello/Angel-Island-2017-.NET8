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

/* Scripts/Mobiles/Monsters/Humanoid/Magic/Pirate.cs	
 * ChangeLog:
 *	7/9/10, adam
 *		o Merge pirate class hierarchy (all pirates are now derived from class Pirate)
 *		o moderate bump in magery to allow the reveal skill on about 50% of pirates (chest guardians)
 *		o Pirate now uses AI_Hybrid
 *  7/02/06, Kit
 *		InitBody/InitOutfit additions
 *	7/26/05, erlein
 *		Automated removal of AoS resistance related function calls. 7 lines removed.
 *	4/13/05, Kit
 *		Switch to new region specific loot model
 *	4/9/05, Adam
 *		Upgrade treasure map level to 4 from 3
 *	1/2/05, Adam
 *		Cleanup pirate name management, make use of Titles
 *			Show title when clicked = true
 *  1/02/05, Jade
 *      Increased speed to bring Pirates up to par with other human IOB kin.
 *	12/11/04, Pix
 *		Changed ControlSlots for IOBF.
 *  12/05/04, Jade
 *      Removed the extra t-map drop.
 *	11/11/04, Pigpen
 *		Changed IOBAlignment from Undead to Pirate as it should be.
 *  11/10/04, Froste
 *      Implemented new random IOB drop system and changed drop change to 12%
 *	11/05/04, Pigpen
 *		Made changes for Implementation of IOBSystem. Changes include:
 *		Removed IsEnemy and Aggressive Action Checks. These are now handled in BaseCreature.cs
 *		Set Creature IOBAlignment to Pirate.
 *	8/23/04, Adam
 * 		Set ShowFameTitle{ get{ return false; } }
 *	8/9/04, Adam
 *		1. Make murderer hue (red)
 *		2. move FAME to ctor from ondeath
 *		3. Add level 3 treasure map as loot (5% chance)
 *		4. Switch Fencing skill for swords
 *		5. Have the pirate use a Cutlass 50% of the time, otherwise a Scimitar
 *		6. Add 10-20 Mandrake Root to pirate drop
 *	7/21/04, mith
 *		IsEnemy() and AggressiveAction() code added to support Brethren property of BloodDrenchedBandana.
 *	7/6/04, Adam
 *		1. implement Jade's new Category Based Drop requirements
 *	4/13/04 Changes by smerX
 * 		Added pirate trash talk
 *	4/09/04 Created by smerX
 */

using Server.Engines.IOBSystem;
using Server.Items;
using System.Collections;

namespace Server.Mobiles
{
    [CorpseName("corpse of a salty seadog")]
    public class Pirate : BaseCreature
    {
        private TimeSpan m_SpeechDelay = TimeSpan.FromSeconds(10.0); // time between pirate speech
        protected TimeSpan SpeechDelay { get { return m_SpeechDelay; } }
        private DateTime m_NextSpeechTime;
        protected DateTime NextSpeechTime { get { return m_NextSpeechTime; } set { m_NextSpeechTime = value; } }
        public override int TreasureMapLevel { get { return Core.UOAI || Core.UOREN ? 4 : 0; } }
        public override bool AlwaysMurderer { get { return true; } }
        public override bool CanRummageCorpses { get { return Core.UOAI || Core.UOREN ? true : false; } }
        public override bool ShowFameTitle { get { return false; } }
        public override bool ClickTitle { get { return true; } }
        private int m_Version;
        protected int Version { get { return m_Version; } }

        public Pirate(AIType ai)
            : base(ai, FightMode.All | FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            IOBAlignment = IOBAlignment.Pirate;
            Hue = Utility.RandomSkinHue();
            SpeechHue = Utility.RandomDyedHue();
            m_NextSpeechTime = DateTime.UtcNow + m_SpeechDelay;

            FightStyle = FightStyle.Melee | FightStyle.Magic | FightStyle.Smart | FightStyle.Bless | FightStyle.Curse;
            UsesHumanWeapons = false;
            UsesBandages = true;
            UsesPotions = true;
            CanRun = true;
            CanReveal = true; // magic and smart

            PackItem(new Bandage(Utility.RandomMinMax(60, 100)));
            PackStrongPotions(6, 12);
            PackItem(new Pouch());

            InitClass();
            InitBody();
            InitOutfit();
        }

        [Constructable]
        public Pirate()
            : this(AIType.AI_Hybrid)
        {
        }

        public override void InitClass()
        {
            ControlSlots = 4;

            SetStr(401, 430);
            SetDex(133, 152);
            SetInt(70, 80);

            SetHits(241, 258);

            VirtualArmor = 46;

            SetDamage(16, 22);

            SetSkill(SkillName.Swords, 65.1, 80.0);
            SetSkill(SkillName.Tactics, 65.1, 90.0);
            SetSkill(SkillName.Healing, 65.1, 90.0);
            SetSkill(SkillName.Magery, 50.0, 90.0);         // reveal at 70, we also want about a 50% chance to be able to reveal, i.e., 70+-20
            SetSkill(SkillName.MagicResist, 65.1, 80.0);

            Fame = 15000;
            Karma = -15000;
        }

        public override void InitBody()
        {
            //if (Female = Utility.RandomBool())
            if (Female)
            {
                Body = 0x191;
                // "Lizzie" "the Black"
                Name = NameList.RandomName("pirate_female");
                Title = NameList.RandomName("pirate_title");
            }
            else
            {
                Body = 0x190;
                if (Utility.RandomBool())
                {
                    // "John" "the Black"
                    Name = NameList.RandomName("pirate_male");
                    Title = NameList.RandomName("pirate_title");
                }
                else
                {
                    // "John" "Black""Beard"
                    Name = NameList.RandomName("pirate_male") + " " + NameList.RandomName("pirate_color") + NameList.RandomName("pirate_part");
                }
            }
        }
        public override void InitOutfit()
        {
            WipeLayers();

            switch (Utility.Random(2))
            {
                case 0: AddItem(new SkullCap(Utility.RandomRedHue())); break;
                case 1: AddItem(new TricorneHat(Utility.RandomRedHue())); break;
            }


            if (Utility.RandomBool())
            {
                Item shirt = new Shirt(Utility.RandomRedHue());
                AddItem(shirt);
            }

            Item sash = new BodySash(0x85);
            Item hair = new Item(Utility.RandomList(0x203B, 0x203C, 0x203D, 0x2044, 0x2045, 0x2047, 0x2049, 0x204A));
            Item pants = new LongPants(Utility.RandomRedHue());
            Item boots = new Boots(Utility.RandomRedHue());
            hair.Hue = Utility.RandomHairHue();
            hair.Layer = Layer.Hair;
            hair.Movable = false;

            Item sword;
            if (Utility.RandomBool())
                sword = new Scimitar();
            else
                sword = new Cutlass();

            sword.LootType = LootType.Newbied;
            sword.Movable = false;              // casts with it equiped

            AddItem(hair);
            AddItem(sash);
            AddItem(pants);
            AddItem(boots);
            AddItem(sword);

            if (!this.Female)
            {
                Item beard = new Item(Utility.RandomList(0x203E, 0x203F, 0x2040, 0x2041, 0x204B, 0x204C, 0x204D));
                beard.Hue = hair.Hue;
                beard.Layer = Layer.FacialHair;
                beard.Movable = false;
                AddItem(beard);
            }
        }
        public override void OnThink()
        {
            if (DateTime.UtcNow >= m_NextSpeechTime)
            {
                Mobile combatant = this.Combatant;

                if (combatant != null && combatant.Map == this.Map && combatant.InRange(this, 8))
                {
                    int phrase = Utility.Random(4);

                    switch (phrase)
                    {
                        case 0: this.Say(true, "Lights and liver!"); break;
                        case 1: this.Say(true, "Arr! Get ye a-swabbin' or yer life ends now!"); break;
                        case 2: this.Say(true, "I'll rip off yer fins and burn ya to slow fire!"); break;
                        case 3: this.Say(true, "Keel haul ye we will!"); break;
                    }

                    m_NextSpeechTime = DateTime.UtcNow + m_SpeechDelay;
                }

                base.OnThink();
            }

        }

        protected TricorneHat CaptainsHat(string title)
        {
            // black captain's hat
            TricorneHat hat = new TricorneHat();
            hat.IOBAlignment = IOBAlignment.Pirate;
            hat.Name = title;
            hat.Hue = 0x01;
            hat.Dyable = false;
            return hat;
        }

        public override void GenerateLoot()
        {
            if (Core.UOAI || Core.UOREN)
            {
                PackGem();
                PackMagicEquipment(1, 3);
                PackGold(200, 250);

                // Category 2 MID
                PackMagicItem(1, 1, 0.05);

                // TreasureMap
                //	5% chance to get a level 3 treasure map
                //  removed this tmap drop

                // Froste: 12% random IOB drop
                if (0.12 > Utility.RandomDouble())
                {
                    Item iob = Loot.RandomIOB();
                    PackItem(iob);
                }

                // pack bulk reg
                PackItem(new MandrakeRoot(Utility.RandomMinMax(10, 20)));

                if (IOBRegions.GetIOBStronghold(this) == IOBAlignment)
                {
                    // 30% boost to gold
                    PackGold(base.GetGold() / 3);
                }
            }
            else
            {
                if (Core.UOSP || Core.UOMO)
                {   // ai special
                    if (Spawning)
                    {
                        PackGold(0);
                    }
                    else
                    {
                    }
                }
                else
                {
                    // ai special
                }
            }
        }

        public override void Damage(int amount, Mobile from, object source_weapon)
        {
            Mobile combatant = this.Combatant;

            if (combatant != null && combatant.Map == this.Map && combatant.InRange(this, 8))
            {
                if (Utility.RandomBool())
                {

                    int phrase = Utility.Random(4);

                    switch (phrase)
                    {
                        case 0: this.Say(true, "Har! The mackerel wiggles!"); break;
                        case 1: this.Say(true, "Ye stink like a rotten clam! Bring it on yet!?"); break;
                        case 2: this.Say(true, "Arr, treacherous monkey!"); break;
                        case 3: this.Say(true, "Ye'll not get my swag!"); break;
                    }

                    m_NextSpeechTime = DateTime.UtcNow + m_SpeechDelay;
                }
            }

            base.Damage(amount, from, source_weapon: source_weapon);
        }

        public override bool OnBeforeDeath()
        {
            int phrase = Utility.Random(2);

            switch (phrase)
            {
                case 0: this.Say(true, "Heh! On to Davy Jones' lockarrr.."); break;
                case 1: this.Say(true, "Sink me!"); break;
            }
            return base.OnBeforeDeath();
        }

        public override void GetContextMenuEntries(Mobile from, ArrayList list)
        {
            base.GetContextMenuEntries(from, list);

            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] is ContextMenus.PaperdollEntry)
                    list.RemoveAt(i--);
            }
        }

        public Pirate(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            m_Version = reader.ReadInt();
        }
    }
}
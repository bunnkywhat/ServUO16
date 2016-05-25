using System;

namespace Server.Items
{
    [FlipableAttribute(0x26BD, 0x26C7)]
    public class BladedStaff : BaseSpear
    {
        [Constructable]
        public BladedStaff()
            : base(0x26BD)
        {
            this.Weight = 4.0;
        }

        public BladedStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get
            {
                return WeaponAbility.ArmorIgnore;
            }
        }
        public override WeaponAbility SecondaryAbility
        {
            get
            {
                return WeaponAbility.Dismount;
            }
        }

        public override int InitMinHits
        {
            get
            {
                return 21;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 110;
            }
        }
        public override SkillName DefSkill
        {
            get
            {
                return SkillName.Swords;
            }
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
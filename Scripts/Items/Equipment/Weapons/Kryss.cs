using System;

namespace Server.Items
{
    [FlipableAttribute(0x1401, 0x1400)]
    public class Kryss : BaseSword
    {
        [Constructable]
        public Kryss()
            : base(0x1401)
        {
            this.Weight = 2.0;
        }

        public Kryss(Serial serial)
            : base(serial)
        {
        }

        public override int OldStrengthReq
        {
            get
            {
                return 10;
            }
        }
        public override int OldMinDamage
        {
            get
            {
                return 3;
            }
        }
        public override int OldMaxDamage
        {
            get
            {
                return 28;
            }
        }
        public override int OldSpeed
        {
            get
            {
                return 53;
            }
        }
        public override int DefHitSound
        {
            get
            {
                return 0x23C;
            }
        }
        public override int DefMissSound
        {
            get
            {
                return 0x238;
            }
        }
        public override int InitMinHits
        {
            get
            {
                return 31;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 90;
            }
        }
        public override SkillName DefSkill
        {
            get
            {
                return SkillName.Fencing;
            }
        }
        public override WeaponType DefType
        {
            get
            {
                return WeaponType.Piercing;
            }
        }
        public override WeaponAnimation DefAnimation
        {
            get
            {
                return WeaponAnimation.Pierce1H;
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

            if (this.Weight == 1.0)
                this.Weight = 2.0;
        }
    }
}
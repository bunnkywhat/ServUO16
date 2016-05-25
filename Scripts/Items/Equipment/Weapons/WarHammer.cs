using System;

namespace Server.Items
{
    [FlipableAttribute(0x1439, 0x1438)]
    public class WarHammer : BaseBashing
    {
        [Constructable]
        public WarHammer()
            : base(0x1439)
        {
            this.Weight = 10.0;
            this.Layer = Layer.TwoHanded;
        }

        public WarHammer(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get
            {
                return WeaponAbility.WhirlwindAttack;
            }
        }
        public override WeaponAbility SecondaryAbility
        {
            get
            {
                return WeaponAbility.CrushingBlow;
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
                return 110;
            }
        }
        public override WeaponAnimation DefAnimation
        {
            get
            {
                return WeaponAnimation.Bash2H;
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
using System;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class OrcishBow : Bow
    {
        [Constructable]
        public OrcishBow()
        {
            Hue = 0x497;

            Name = "an orcish bow";
        }

        public OrcishBow(Serial serial)
            : base(serial)
        {
        }

 
        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add(1060410, 70.ToString()); // durability ~1_val~%
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
using System;
using Server.Engines.Quests;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Engines.Harvest
{
    public class HarvestTarget : Target
    {
        private readonly Item m_Tool;
        private readonly HarvestSystem m_System;
        public HarvestTarget(Item tool, HarvestSystem system)
            : base(-1, true, TargetFlags.None)
        {
            this.m_Tool = tool;
            this.m_System = system;

            this.DisallowMultis = true;
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            if (this.m_System is Lumberjacking && targeted is IChopable)
                ((IChopable)targeted).OnChop(from);
            else if (this.m_System is Lumberjacking && targeted is IAxe && this.m_Tool is BaseAxe)
            {
                IAxe obj = (IAxe)targeted;
                Item item = (Item)targeted;
					
                if (!item.IsChildOf(from.Backpack))
                    from.SendLocalizedMessage(1062334); // This item must be in your backpack to be used.
                else if (obj.Axe(from, (BaseAxe)this.m_Tool))
                    from.PlaySound(0x13E);
            }
            else if (this.m_System is Lumberjacking && targeted is ICarvable)
                ((ICarvable)targeted).Carve(from, (Item)this.m_Tool);
            else if (this.m_System is Lumberjacking && FurnitureAttribute.Check(targeted as Item))
                this.DestroyFurniture(from, (Item)targeted);
            else if (this.m_System is Mining && targeted is TreasureMap)
                ((TreasureMap)targeted).OnBeginDig(from);
			else
			{
				// If we got here and we're lumberjacking then we didn't target something that cna be done from the pack
				if (m_System is Lumberjacking && m_Tool.Parent != from)
				{
					from.SendLocalizedMessage(500487); // The axe must be equipped for any serious wood chopping.
					return;
				}
				this.m_System.StartHarvesting(from, this.m_Tool, targeted);
			}
        }

        private void DestroyFurniture(Mobile from, Item item)
        {
            if (!from.InRange(item.GetWorldLocation(), 3))
            {
                from.SendLocalizedMessage(500446); // That is too far away.
                return;
            }
            else if (!item.IsChildOf(from.Backpack) && !item.Movable)
            {
                from.SendLocalizedMessage(500462); // You can't destroy that while it is here.
                return;
            }

            from.SendLocalizedMessage(500461); // You destroy the item.
            Effects.PlaySound(item.GetWorldLocation(), item.Map, 0x3B3);

            if (item is Container)
            {
                if (item is TrapableContainer)
                    (item as TrapableContainer).ExecuteTrap(from);

                ((Container)item).Destroy();
            }
            else
            {
                item.Delete();
            }
        }
    }
}
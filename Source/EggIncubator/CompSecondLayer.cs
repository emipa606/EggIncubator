using RimWorld;
using Verse;

namespace EggIncubator
{
    // Token: 0x02000002 RID: 2
    internal class CompSecondLayer : ThingComp
    {
        // Token: 0x04000001 RID: 1
        private Graphic graphicInt;

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        private CompProperties_SecondLayer Props => (CompProperties_SecondLayer) props;

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000002 RID: 2 RVA: 0x00002070 File Offset: 0x00000270
        private Graphic Graphic
        {
            get
            {
                if (graphicInt != null)
                {
                    return graphicInt;
                }

                if (Props.graphicData == null)
                {
                    Log.ErrorOnce(parent.def + " has no SecondLayer graphicData but we are trying to access it.",
                        764532);
                    return BaseContent.BadGraphic;
                }

                graphicInt = Props.graphicData.GraphicColoredFor(parent);

                return graphicInt;
            }
        }

        // Token: 0x06000003 RID: 3 RVA: 0x000020F0 File Offset: 0x000002F0
        public override void PostDraw()
        {
            base.PostDraw();
            Log.Message($"Drawing cover for {parent}");
            Graphic.Draw(GenThing.TrueCenter(parent.Position, parent.Rotation, parent.def.size, Props.Altitude),
                parent.Rotation, parent);
        }
    }
}
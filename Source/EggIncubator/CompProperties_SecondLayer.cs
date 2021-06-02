using Verse;

namespace EggIncubator
{
    // Token: 0x02000003 RID: 3
    internal class CompProperties_SecondLayer : CompProperties
    {
        // Token: 0x04000003 RID: 3
        private AltitudeLayer altitudeLayer;

        // Token: 0x04000002 RID: 2
        public GraphicData graphicData;

        // Token: 0x06000006 RID: 6 RVA: 0x00002181 File Offset: 0x00000381
        public CompProperties_SecondLayer()
        {
            compClass = typeof(CompSecondLayer);
        }

        // Token: 0x17000003 RID: 3
        // (get) Token: 0x06000005 RID: 5 RVA: 0x00002164 File Offset: 0x00000364
        public float Altitude => altitudeLayer.AltitudeFor();
    }
}
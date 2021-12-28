using RimWorld;
using Verse;

namespace EggIncubator;

internal class CompSecondLayer : ThingComp
{
    private Graphic graphicInt;

    private CompProperties_SecondLayer Props => (CompProperties_SecondLayer)props;

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

    public override void PostDraw()
    {
        base.PostDraw();
        //Log.Message($"Drawing cover for {parent}");
        Graphic.Draw(GenThing.TrueCenter(parent.Position, parent.Rotation, parent.def.size, Props.Altitude),
            parent.Rotation, parent);
    }
}
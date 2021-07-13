using RimWorld;
using Verse;

namespace SlagRefinedPlus
{
    // Token: 0x02000006 RID: 6
    public class IncidentWorker_SlagScatter : IncidentWorker_ResourcePodCrash
    {
        // Token: 0x06000009 RID: 9 RVA: 0x00002394 File Offset: 0x00000594
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            var activeSlagPodDef = (ActiveSlagPodDef) ThingDef.Named("ActiveSlagPod");
            bool result;
            if (activeSlagPodDef == null)
            {
                Log.Error("ActiveSlagPod was not defined!");
                result = false;
            }
            else if (activeSlagPodDef.slagpodContents == null)
            {
                Log.Error("slagpodContents was not defined in ActiveSlagPod!");
                result = false;
            }
            else
            {
                var things = activeSlagPodDef.slagpodContents.root.Generate();
                var map = (Map) parms.target;
                var intVec = DropCellFinder.RandomDropSpot(map);
                SlagPodUtility.DropThingsNear(intVec, map, things, 1, false, true, true);
                Find.LetterStack.ReceiveLetter("LetterLabelSlagPodDrop".Translate(), "SlagPodDrop".Translate(),
                    LetterDefOf.PositiveEvent, new TargetInfo(intVec, map));
                result = true;
            }

            return result;
        }
    }
}
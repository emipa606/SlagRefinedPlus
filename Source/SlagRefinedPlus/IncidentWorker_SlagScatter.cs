using System;
using System.Collections.Generic;
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
			ActiveSlagPodDef activeSlagPodDef = (ActiveSlagPodDef)ThingDef.Named("ActiveSlagPod");
			bool result;
			if (activeSlagPodDef == null)
			{
				Log.Error("ActiveSlagPod was not defined!", false);
				result = false;
			}
			else if (activeSlagPodDef == null)
			{
				Log.Error("slagpod is not ActiveSlagPod!", false);
				result = false;
			}
			else if (activeSlagPodDef.slagpodContents == null)
			{
				Log.Error("slagpodContents was not defined in ActiveSlagPod!", false);
				result = false;
			}
			else
			{
				List<Thing> things = activeSlagPodDef.slagpodContents.root.Generate();
				Map map = (Map)parms.target;
				IntVec3 intVec = DropCellFinder.RandomDropSpot(map);
				SlagPodUtility.DropThingsNear(intVec, map, things, 1, false, true, true);
				Find.LetterStack.ReceiveLetter(Translator.Translate("LetterLabelSlagPodDrop"), Translator.Translate("SlagPodDrop"), LetterDefOf.PositiveEvent, new TargetInfo(intVec, map, false), null, null);
				result = true;
			}
			return result;
		}
	}
}

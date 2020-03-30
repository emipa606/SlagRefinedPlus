using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace SlagRefinedPlus
{
	// Token: 0x02000002 RID: 2
	public static class SlagPodUtility
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002084 File Offset: 0x00000284
		public static void MakeDropPodAt(IntVec3 c, Map map, ActiveDropPodInfo info)
		{
			ActiveDropPod activeDropPod = (ActiveDropPod)ThingMaker.MakeThing(ThingDef.Named("ActiveSlagPod"), null);
			activeDropPod.Contents = info;
			SkyfallerMaker.SpawnSkyfaller(ThingDef.Named("SlagScatter"), activeDropPod, c, map);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020C4 File Offset: 0x000002C4
		public static void DropThingsNear(IntVec3 dropCenter, Map map, IEnumerable<Thing> things, int openDelay, bool canInstaDropDuringInit, bool leaveSlag, bool canRoofPunch)
		{
			SlagPodUtility.tempList.Clear();
			foreach (Thing item in things)
			{
				List<Thing> list = new List<Thing>();
				list.Add(item);
				SlagPodUtility.tempList.Add(list);
			}
			SlagPodUtility.DropThingGroupsNear(dropCenter, map, SlagPodUtility.tempList, openDelay, canInstaDropDuringInit, leaveSlag, canRoofPunch);
			SlagPodUtility.tempList.Clear();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002158 File Offset: 0x00000358
		public static void DropThingGroupsNear(IntVec3 dropCenter, Map map, List<List<Thing>> thingsGroups, int openDelay, bool instaDrop, bool leaveSlag, bool canRoofPunch)
		{
			foreach (List<Thing> list in thingsGroups)
			{
				IntVec3 intVec;
				if (!DropCellFinder.TryFindDropSpotNear(dropCenter, map, out intVec, true, canRoofPunch))
				{
					Log.Warning(string.Concat(new object[]
					{
						"DropThingsNear failed to find a place to drop ",
						list.FirstOrDefault<Thing>(),
						" near ",
						dropCenter,
						". Dropping on random square instead."
					}), false);
					intVec = CellFinderLoose.RandomCellWith((IntVec3 c) => c.Walkable(map), map, 1000);
				}
				for (int i = 0; i < list.Count; i++)
				{
					list[i].SetForbidden(true, false);
				}
				if (instaDrop)
				{
					foreach (Thing thing in list)
					{
						GenPlace.TryPlaceThing(thing, intVec, map, ThingPlaceMode.Near, null, null);
					}
				}
				else
				{
					ActiveDropPodInfo activeDropPodInfo = new ActiveDropPodInfo();
					foreach (Thing item in list)
					{
						activeDropPodInfo.innerContainer.TryAdd(item, true);
					}
					activeDropPodInfo.openDelay = openDelay;
					activeDropPodInfo.leaveSlag = leaveSlag;
					SlagPodUtility.MakeDropPodAt(intVec, map, activeDropPodInfo);
				}
			}
		}

		// Token: 0x04000001 RID: 1
		private static List<List<Thing>> tempList = new List<List<Thing>>();
	}
}

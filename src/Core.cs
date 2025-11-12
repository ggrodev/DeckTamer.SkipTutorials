using MelonLoader;

[assembly: MelonInfo(typeof(SkipTutorial.Core), "SkipTutorial", "1.0.0", "GGro", null)]
[assembly: MelonGame("Horizon Edge", "Decktamer")]

namespace SkipTutorial
{
	public class Core : MelonMod
	{
		public override void OnInitializeMelon()
		{
			LoggerInstance.Msg("Initialized.");
		}

		bool initialized = false;

		readonly List<(string, bool)> globalFlags = new([
			("TutorialCompleted", true),
			("HasSeenBasicEncounterChoiceTutorial", true),
			("HasSeenSecondPartEncounterChoiceTutorial", true)
			]);

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			if (!initialized)
			{
				foreach (var flag in globalFlags)
				{
					SaveManager.SetGlobalValue<bool>(flag.Item1, flag.Item2);
				}
				SaveManager.SaveToDisk();

				initialized = true;
			}
		}
	}
}
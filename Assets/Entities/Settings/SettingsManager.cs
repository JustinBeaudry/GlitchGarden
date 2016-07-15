using UnityEngine;

[RequireComponent (typeof(PlayerPrefsManager))]
public class SettingsManager : MonoBehaviour
{

	public const float DEFUALT_MUSIC_VOLUME = 0.4f;
	public const float DEFAULT_GAME_VOLUME = 0.7f;
	public const int DEFAULT_DIFFICULTY = 2;
	public const int DEFAULT_LEVEL = 1;

	public static float MusicVolume = DEFUALT_MUSIC_VOLUME;
	public static float GameVolume = DEFAULT_GAME_VOLUME;
	public static int Difficulty = DEFAULT_DIFFICULTY;
	public static int CurrentLevel = DEFAULT_LEVEL;
	public static int Levels = 3;

	protected void Start ()
	{
		UpdateSettingsFromPrefs ();
	}

	public static void SetToDefaults ()
	{
		MusicVolume = DEFUALT_MUSIC_VOLUME;
		GameVolume = DEFAULT_GAME_VOLUME;
		Difficulty = DEFAULT_DIFFICULTY;
		SaveAll ();
	}

	public static void SaveAll ()
	{
		SaveMusicVolume ();
		SaveGameVolume ();
		SaveDifficulty ();
	}

	public static void SaveMusicVolume ()
	{
		PlayerPrefsManager.SetMusicVolume (MusicVolume);
	}

	public static void SaveGameVolume ()
	{
		PlayerPrefsManager.SetGameVolume (GameVolume);
	}

	public static void SaveDifficulty ()
	{
		PlayerPrefsManager.SetDifficulty (Difficulty);
	}

	private static void UpdateSettingsFromPrefs ()
	{
		MusicVolume = PlayerPrefsManager.GetMusicVolume ();
		GameVolume = PlayerPrefsManager.GetGameVolume ();
		Difficulty = PlayerPrefsManager.GetDifficulty ();
	
	}

	public static void NextLevel ()
	{
		if (CurrentLevel + 1 < Levels) {
			CurrentLevel += 1;
		}
	}

	public static void SetLevel (int level)
	{
		if (level < Levels) {
			CurrentLevel = level;
		}
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

	const string MUSIC_VOLUME_KEY = "music_volume";
	const string GAME_VOLUME_KEY = "game_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMusicVolume (float volume)
	{
		if (volume > 0f && volume < 1f) {
			PlayerPrefs.SetFloat (MUSIC_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Music volume out of range");
		}
	}

	public static float GetMusicVolume ()
	{
		return PlayerPrefs.GetFloat (MUSIC_VOLUME_KEY);
	}

	public static void SetGameVolume (float volume)
	{
		if (volume > 0f && volume < 1f) {
			PlayerPrefs.SetFloat (GAME_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Game volume out of range");
		}
	}

	public static float GetGameVolume ()
	{
		return PlayerPrefs.GetFloat (GAME_VOLUME_KEY);
	}

	public static void UnlockLevel (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1);
		} else {
			Debug.LogError ("Trying to unlock level not in build settings");
		}
	}

	public static bool IsLevelUnlocked (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			return (PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ()) == 1);
		} else {
			Debug.LogError ("Trying to access level not in build settings");
			return false;
		}
	}

	public static void SetDifficulty (int difficulty)
	{
		if (difficulty >= 1 && difficulty <= 3) {
			PlayerPrefs.SetInt (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty out of range");
		}
	}

	public static int GetDifficulty ()
	{
		return PlayerPrefs.GetInt (DIFFICULTY_KEY);
	}
}

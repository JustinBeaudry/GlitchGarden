using UnityEngine;
using System.Collections.Generic;

public class SettingsManager : MonoBehaviour
{
	public float musicVolume = 0.0f;
	public float gameVolume = 0.0f;

	private Dictionary<string, float> volumeSettings = new Dictionary<string, float> ();

	protected void Start ()
	{
		DontDestroyOnLoad (this);

		volumeSettings.Add ("musicVolume", musicVolume);
		volumeSettings.Add ("gameVolume", gameVolume);
	}

	public float GetVolumeSettingByName (string setting)
	{
		if (volumeSettings.ContainsKey (setting)) {
			return volumeSettings [setting];
		} else {
			return 0.0f;
		}
	}
}

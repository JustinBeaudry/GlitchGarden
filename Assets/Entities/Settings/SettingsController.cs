using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingsController : MonoBehaviour
{

	private SettingsManager settings;
	private Dictionary<string, System.Action> buttonActions = new Dictionary<string, System.Action> ();
	private Dictionary<string, System.Action<float>> sliderActions = new Dictionary<string, System.Action<float>> ();
	private Dictionary<string, string> settingsToControls = new Dictionary<string, string> ();

	public string musicVolumeControl = "Music Volume Control";
	public string gameVolumeControl = "Game Volume Control";
	public string back = "Back";

	void Start ()
	{
		GameManager.InitGame ("Settings");

		settings = GameObject.Find ("SettingsManager").GetComponent<SettingsManager> ();

		settingsToControls.Add (musicVolumeControl, "musicVolume");
		settingsToControls.Add (gameVolumeControl, "gameVolume");

		sliderActions.Add (musicVolumeControl, OnMusicVolumeChange);
		sliderActions.Add (gameVolumeControl, OnGameVolumeChange);
		buttonActions.Add (back, OnBack);

		foreach (Transform child in GameObject.Find("Settings").transform) {
			if (child.gameObject.GetComponent<Button> () != null && buttonActions.ContainsKey (child.gameObject.name)) {
				Button button = child.gameObject.GetComponent<Button> ();	
				System.Action action = buttonActions [child.gameObject.name];
				ButtonActionHandler (button, action);

			} else if (child.gameObject.GetComponent<Slider> () != null && sliderActions.ContainsKey (child.gameObject.name)) {
				Slider slider = child.gameObject.GetComponent<Slider> ();
				// For each slider set the current slider.value from the appropriate settings
				string settingName = settingsToControls [child.gameObject.name];
				slider.value = settings.GetVolumeSettingByName (settingName);
				System.Action<float> action = sliderActions [child.gameObject.name];
				SliderActionHandler (slider, action);
			}
		}
	}

	void SliderActionHandler (Slider slider, System.Action<float> action)
	{
		// @TODO:  Control Settings can go here	
		slider.onValueChanged.AddListener (delegate {
			action (slider.value);
		});
	}

	void ButtonActionHandler (Button button, System.Action action)
	{
		// @TODO:  Control Settings can go here	
		button.onClick.AddListener (delegate {
			action ();
		});
	}

	void OnBack ()
	{
		GameManager.SwitchToPreviousScene ();
	}

	void OnMusicVolumeChange (float value)
	{
		settings.musicVolume = value;
	}

	void OnGameVolumeChange (float value)
	{
		settings.gameVolume = value;
	}
}

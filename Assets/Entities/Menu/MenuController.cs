using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent (typeof(SettingsManager))]
public class MenuController : MonoBehaviour
{
	public Button StartButton, SettingsButton, QuitButton;
	private MusicPlayer musicPlayer;

	void Awake ()
	{
		GameObject MusicPlayerObject = GameObject.Find ("MusicPlayer");
		if (MusicPlayerObject != null) {
			musicPlayer = MusicPlayerObject.GetComponent<MusicPlayer> ();
		}
	}

	void Start ()
	{
		GameManager.InitGame ();
		if (musicPlayer != null) {
			musicPlayer.ChangeAudio ("Main_Menu");
		}
		BindActionHandlers ();
	}

	void BindActionHandlers ()
	{
		StartButton.onClick.AddListener (OnStart);
		SettingsButton.onClick.AddListener (OnSettings);
		QuitButton.onClick.AddListener (OnQuit);
	}

	void OnStart ()
	{
		GameManager.SwitchScene ("Level_0" + SettingsManager.CurrentLevel.ToString ());
	}

	void OnSettings ()
	{
		GameManager.LoadSceneAdditive ("Settings");
	}

	void OnQuit ()
	{
		Application.Quit ();
	}
}

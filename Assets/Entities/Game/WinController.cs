using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(SettingsManager))]
// @TODO:  Move this logic to the menu and have conditions for when to display particular UI elements
public class WinController : MonoBehaviour
{

	public Button RetryButton, SettingsButton, QuitButton;
	private MusicPlayer musicPlayer;

	void Awake ()
	{
		musicPlayer = FindObjectOfType<MusicPlayer> ();
	}

	void Start ()
	{
		GameManager.InitGame ();
		if (musicPlayer != null) {
			musicPlayer.ChangeAudio ("Win");
		}
		BindActionHandlers ();
	}

	void BindActionHandlers ()
	{
		RetryButton.onClick.AddListener (OnRetry);
		SettingsButton.onClick.AddListener (OnSettings);
		QuitButton.onClick.AddListener (OnQuit);
	}

	void OnRetry ()
	{
		GameManager.SwitchScene ("Level_0" + SettingsManager.CurrentLevel.ToString ());
	}

	void OnSettings ()
	{
		GameManager.SwitchScene ("Settings");
	}

	void OnQuit ()
	{
		Application.Quit ();
	}
}

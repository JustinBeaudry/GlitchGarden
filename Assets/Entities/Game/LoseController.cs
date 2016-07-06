using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(SettingsManager))]
// @TODO:  Move this logic to the menu and have conditions for when to display particular UI elements
public class LoseController : MonoBehaviour
{

	public Button RetryButton, SettingsButton, QuitButton;
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
			musicPlayer.ChangeAudio ("Lose");
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
		GameManager.SwitchScene (SettingsManager.CurrentLevel);
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

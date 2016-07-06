using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(SettingsManager))]
public class GameController : MonoBehaviour
{

	private MusicPlayer musicPlayer;
	bool DisplayingGameMenu = false;

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
			musicPlayer.ChangeAudio (SettingsManager.CurrentLevel);
		}
	}

	void Update ()
	{
		// @TODO:  Move this to PlayerControlsManager
		if (Input.GetKey (KeyCode.Escape) && !DisplayingGameMenu) {
			GameManager.LoadSceneAdditive ("Game_Menu");
		}
	}

	public void UpdateGameMenuDisplayState (bool state)
	{
		DisplayingGameMenu = state;
	}

	void OnWin ()
	{
		GameManager.SwitchScene ("Win");
	}

	void OnLose ()
	{
		GameManager.SwitchScene ("Lose");
	}
}

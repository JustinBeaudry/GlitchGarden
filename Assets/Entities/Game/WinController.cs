using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WinController : MonoBehaviour
{

	private MusicPlayer musicPlayer;
	Dictionary<string, System.Action> menuActions = new Dictionary<string, System.Action> ();

	void Start ()
	{
		GameManager.InitGame ();
		musicPlayer = GameObject.Find ("MusicPlayer").GetComponent<MusicPlayer> ();
		musicPlayer.ChangeAudio ("Win");

		menuActions.Add ("Retry", OnStart);
		menuActions.Add ("Settings", OnSettings);
		menuActions.Add ("Quit", OnQuit);

		foreach (Transform child in GameObject.Find("Menu").transform) {
			Button button = child.gameObject.GetComponent<Button> ();
			System.Action action = menuActions [child.gameObject.name];
			button.onClick.AddListener (delegate {
				action ();
			});
		}
	}

	void OnStart ()
	{
		GameManager.SwitchScene ("Level_01");
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

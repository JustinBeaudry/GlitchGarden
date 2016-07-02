using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

	private MusicPlayer musicPlayer;
	private Dictionary<string, System.Action> controls = new Dictionary<string, System.Action> ();

	void Start ()
	{
		GameManager.InitGame ("Level_01");
		musicPlayer = GameObject.Find ("MusicPlayer").GetComponent<MusicPlayer> ();
		musicPlayer.ChangeAudio ("Level_01");

		controls.Add ("Win", OnWin);
		controls.Add ("Lose", OnLose);

		foreach (Transform child in GameObject.Find("Controls").transform) {
			Button button = child.gameObject.GetComponent<Button> ();
			System.Action action = controls [child.gameObject.name];
			button.onClick.AddListener (delegate {
				action ();
			});
		}
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

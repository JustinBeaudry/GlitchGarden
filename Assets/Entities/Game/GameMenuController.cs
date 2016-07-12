using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{

	public Button ResumeButton, SettingsButton, QuitButton;
	private GameController gameController;

	void Awake ()
	{
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}

	void Start ()
	{
		gameController.Pause ();
		gameController.UpdateGameMenuDisplayState (true);
		BindActionHandlers ();
	}

	void BindActionHandlers ()
	{
		ResumeButton.onClick.AddListener (OnResume);
		SettingsButton.onClick.AddListener (OnSettings);
		QuitButton.onClick.AddListener (OnQuit);
	}

	void OnResume ()
	{
		GameManager.UnloadSceneAdditive ("Game_Menu");
		gameController.UpdateGameMenuDisplayState (false);
		gameController.Play ();
	}

	void OnSettings ()
	{
		GameManager.LoadSceneAdditive ("Settings");
	}

	void OnQuit ()
	{
		GameManager.SwitchScene ("Main_Menu");
	}
}

using UnityEngine;

[RequireComponent (typeof(SettingsManager))]
public class GameController : MonoBehaviour
{
	public enum GameStates
	{
		Play,
		Pause}

	;

	public GameStates GameState;

	private MusicPlayer musicPlayer;
	private bool DisplayingGameMenu = false;

	void Awake ()
	{
		musicPlayer = FindObjectOfType<MusicPlayer> ();
	}

	void Start ()
	{
		GameState = GameStates.Play;
		GameManager.InitGame ();
		Player.Stars = Player.DEFAULT_STARS;
		if (musicPlayer != null) {
			musicPlayer.ChangeAudio ("Level_0" + SettingsManager.CurrentLevel.ToString ());
		}
	}

	void Update ()
	{
		// @TODO:  Move this to PlayerControlsManager
		if (Input.GetKey (KeyCode.Escape)) {
			OpenGameMenu ();
		}

		if (GameState == GameStates.Pause) {
			Time.timeScale = 0;
		} else if (GameState == GameStates.Play) {
			Time.timeScale = 1;
		}
	}

	public void Play ()
	{
		GameState = GameStates.Play;
	}

	public void Pause ()
	{
		GameState = GameStates.Pause;
	}

	public void OpenGameMenu ()
	{
		if (!DisplayingGameMenu) {
			GameManager.LoadSceneAdditive ("Game_Menu");
		}	
	}

	public void UpdateGameMenuDisplayState (bool state)
	{
		DisplayingGameMenu = state;
	}

	public void Win ()
	{
		GameManager.SwitchScene ("Win");
	}

	public void Lose ()
	{
		GameManager.SwitchScene ("Lose");
	}
}

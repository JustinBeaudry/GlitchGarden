using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

	public float LevelSeconds = 100f;

	private float TimeRemaining = 0f;
	private Text text;
	private AudioSource audioSource;
	private GameController game;
	private MusicPlayer musicPlayer;
	private bool GameOver = false;

	void Start ()
	{
		text = GetComponent<Text> ();
		audioSource = GetComponent<AudioSource> ();
		game = FindObjectOfType<GameController> ();
		musicPlayer = FindObjectOfType<MusicPlayer> ();
	}

	void Update ()
	{
		TimeRemaining = LevelSeconds -= Time.deltaTime;

		string minutes = Mathf.Abs (Mathf.Floor (TimeRemaining / 60)).ToString ("00");
		string seconds = Mathf.Abs (Mathf.Floor (TimeRemaining % 60)).ToString ("00");

		text.text = minutes + ":" + seconds;

		if (Mathf.Approximately (TimeRemaining, 0) && !GameOver) {
			GameOver = true;
			musicPlayer.StopAudio ();
			audioSource.Play ();
			Invoke ("Win", audioSource.clip.length);
		}
	}

	private void Win ()
	{
		game.Win ();
	}
}


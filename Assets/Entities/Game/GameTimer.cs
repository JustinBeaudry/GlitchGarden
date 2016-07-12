using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

	public float LevelSeconds = 100f;

	private Slider slider;
	private AudioSource audioSource;
	private GameController game;
	private MusicPlayer musicPlayer;
	private bool GameOver = false;

	void Start ()
	{
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		game = FindObjectOfType<GameController> ();
		musicPlayer = FindObjectOfType<MusicPlayer> ();
	}

	void Update ()
	{
		slider.value = Time.timeSinceLevelLoad / LevelSeconds;
		if (Time.timeSinceLevelLoad >= LevelSeconds && !GameOver) {
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


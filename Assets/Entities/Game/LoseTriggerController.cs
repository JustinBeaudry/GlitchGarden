using UnityEngine;

public class LoseTriggerController : MonoBehaviour
{
	GameController game;

	void Start ()
	{
		game = FindObjectOfType<GameController> ();
	}

	void OnTriggerEnter2D ()
	{
		game.Lose ();
	}

}

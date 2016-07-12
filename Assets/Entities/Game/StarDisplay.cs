using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
	Text text;

	void Awake ()
	{
		text = GetComponent<Text> ();
	}

	void Update ()
	{
		text.text = Player.Stars.ToString ();
	}
}

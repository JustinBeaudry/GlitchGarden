using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DefenderSpawnButtonContainer : MonoBehaviour
{
	public Text cost;
	public Text count;
	public Defender defender;


	void Start ()
	{
		cost.text = defender.Cost.ToString ();
	}

	void Update ()
	{
		count.text = GameObject.FindGameObjectsWithTag ("Defender").Length.ToString ();
	}
}

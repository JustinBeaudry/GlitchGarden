using UnityEngine;

public class InactiveOnInvisible : MonoBehaviour
{
	void OnBecameInvisible ()
	{
		gameObject.SetActive (false);
	}
}


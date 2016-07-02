using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BGController : MonoBehaviour
{

	public Sprite[] bgs;
	private Image image;

	void Start ()
	{
		image = GetComponent<Image> ();
		image.sprite = GetRandomSprite ();
	}

	Sprite GetRandomSprite ()
	{
		return bgs [(int)Random.Range (0.0f, (float)bgs.Length)];
	}
}

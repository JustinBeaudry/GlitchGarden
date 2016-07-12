using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class DefenderSpawnButton : MonoBehaviour
{
	public GameObject Defender;
	public static GameObject Selected;

	private static List<GameObject> Buttons;
	private bool Enabled = true;
	private Image sprite;

	void Awake ()
	{
		if (Buttons == null) {
			Buttons = new List<GameObject> ();
		}
		Buttons.Add (gameObject);
	}

	void OnDestroy ()
	{
		Buttons.Remove (gameObject);
		if (Buttons.Count == 0) {
			Buttons = null;
		}
	}

	void Start ()
	{
		sprite = GetComponent<Image> ();
		sprite.color = Color.gray;
	}

	void Update ()
	{
		bool AbleToPurchase = Player.Stars >= Defender.GetComponent<Defender> ().Cost;

		if (AbleToPurchase) {
			Enabled = true;
			if (Selected != null && Defender.name == Selected.name) {
				sprite.color = Color.white;
			} else {
				sprite.color = Color.gray;
			}
		} else {
			Enabled = false;
			sprite.color = Color.black;
		}
	}

	void OnMouseDown ()
	{
		if (Enabled) {
			sprite.color = Color.white;
			SelectDefender ();
			foreach (GameObject obj in Buttons.Where(obj => obj.name != name)) {
				obj.GetComponent<SpriteRenderer> ().color = Color.gray;
			}
		} else {
			ClearDefender ();
		}
	}

	private static void ClearDefender ()
	{
		Selected = null;
	}

	private void SelectDefender ()
	{
		Selected = Defender;
	}
}

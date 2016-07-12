using UnityEngine;

public class DefenderSpawn : MonoBehaviour
{
	private GameObject DefenderContainer;

	void Start ()
	{
		DefenderContainer = GameObject.Find ("Defenders");
		if (!DefenderContainer) {
			DefenderContainer = new GameObject ("Defenders");
		}
	}

	void OnMouseDown ()
	{
		GameObject selected = DefenderSpawnButton.Selected;
		if (selected && Player.UseStars (selected.GetComponent<Defender> ().Cost)) {
			Vector2 pos = SnapToGrid (Camera.main.ScreenToWorldPoint (Input.mousePosition));
			GameObject defender = Instantiate (selected, pos, Quaternion.identity) as GameObject;
			defender.transform.parent = DefenderContainer.transform;
		}
	}

	Vector2 SnapToGrid (Vector2 pos)
	{
		float x = (float)Mathf.RoundToInt (pos.x);
		float y = (float)Mathf.RoundToInt (pos.y);

		return new Vector2 (x, y);
	}

}


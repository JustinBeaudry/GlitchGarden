using UnityEngine;

[RequireComponent (typeof(Attacker))]

public class Lizard : MonoBehaviour
{
	private AttackBehavior attackBehavior;

	protected void Start ()
	{
		attackBehavior = GetComponent<AttackBehavior> ();
	}

	protected void OnTriggerEnter2D (Collider2D collider)
	{
		Interact (collider.gameObject);
	}

	private void Interact (GameObject actor)
	{
		if (!actor.GetComponent<Defender> ()) {
			return;
		}

		attackBehavior.Attack (actor);
	}
}

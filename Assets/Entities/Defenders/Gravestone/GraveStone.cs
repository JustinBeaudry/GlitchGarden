using UnityEngine;

[RequireComponent (typeof(AttackBehavior))]
[RequireComponent (typeof(Defender))]

public class GraveStone : MonoBehaviour
{

	private AttackBehavior attackBehavior;

	void Start ()
	{
		attackBehavior = GetComponent<AttackBehavior> ();
	}

	protected void OnTriggerEnter2D (Collider2D collider)
	{
		Interact (collider.gameObject);
	}

	private void Interact (GameObject actor)
	{
		if (!actor.GetComponent<Attacker> ()) {
			return;
		}

		attackBehavior.Attack (actor);
	}

}

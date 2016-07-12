using UnityEngine;

[RequireComponent (typeof(Move))]
[RequireComponent (typeof(AttackBehavior))]

public class Projectile : MonoBehaviour
{
	private AttackBehavior attackBehavior;
	private Move move;

	void Start ()
	{
		move = GetComponent<Move> ();
		attackBehavior = GetComponent<AttackBehavior> ();

		if (move) {
			move.SetDirection (Vector3.right);
		}
	}

	protected void OnTriggerEnter2D (Collider2D collider)
	{
		Interact (collider.gameObject);
	}

	private void Interact (GameObject actor)
	{
		if (actor.GetComponent<Attacker> ()) {
			attackBehavior.Attack (actor);
			attackBehavior.StrikeCurrentTarget ();
			Destroy (gameObject);
		}
	}
}

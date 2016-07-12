using UnityEngine;

[RequireComponent (typeof(AttackBehavior))]
[RequireComponent (typeof(Animator))]

public class Fox : MonoBehaviour
{
	private Animator animator;
	private AttackBehavior attackBehavior;

	void Start ()
	{
		animator = GetComponent<Animator> ();
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

		if (actor.GetComponent<GraveStone> ()) {
			animator.SetTrigger ("Jump");
			return;
		} 

		attackBehavior.Attack (actor);
	}
}

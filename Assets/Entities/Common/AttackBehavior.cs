using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(Animator))]

public class AttackBehavior : MonoBehaviour
{
	public float Damage = 1f;

	private Animator animator;
	private GameObject currentTarget;

	private readonly List<string> parameters = new List<string> ();

	void Start ()
	{
		animator = GetComponent<Animator> ();
		if (animator) {
			foreach (AnimatorControllerParameter param in animator.parameters) {
				parameters.Add (param.name);
			}
		}
	}

	void Update ()
	{
		if (!currentTarget) {
			SetAttackingParam (false);
		}
	}

	public void StrikeCurrentTarget ()
	{
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();

			if (health) {
				health.Damage (Damage);
			}
		}
	}

	public void Attack (GameObject target)
	{
		SetAttackingParam (true);
		currentTarget = target;
	}

	private void SetAttackingParam (bool attacking)
	{
		if (parameters.Contains ("IsAttacking")) {
			animator.SetBool ("IsAttacking", attacking);
		}
	}
}


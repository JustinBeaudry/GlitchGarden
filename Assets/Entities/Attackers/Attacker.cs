using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Health))]
[RequireComponent (typeof(Move))]

public class Attacker : MonoBehaviour
{
	[Tooltip ("Average number of seconds between appearances.")]
	public float SeenEverySeconds;

	private Move move;

	void Awake ()
	{
		SeenEverySeconds = Time.time;
	}

	void Start ()
	{
		move = GetComponent<Move> ();

		if (move) {
			move.SetDirection (Vector3.left);
		}
	}
}

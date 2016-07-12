using UnityEngine;

[RequireComponent (typeof(Animator))]

public class StarTrophy : MonoBehaviour
{
	public int Value = 1;
	public float StarSpawnDelay = 2f;

	private float LastSpawnTime = 0f;

	private Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void Update ()
	{
		if (Time.timeSinceLevelLoad > (LastSpawnTime + StarSpawnDelay)) {
			LastSpawnTime = Time.timeSinceLevelLoad;
			animator.SetTrigger ("Generate");
		}
	}

	public void AddStars ()
	{
		Player.AddStars (Value);
	}
}

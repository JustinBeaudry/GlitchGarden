using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] Spawns;
	public bool SpawnEnabled = true;

	void Awake ()
	{
		if (Spawns == null || Spawns.Length == 0) {
			Debug.LogError ("Spawners need a list of attackers.");
		}
	}

	void Update ()
	{
		if (!SpawnEnabled) {
			return;
		}

		foreach (GameObject spawn in Spawns) {
			if (IsTimeToSpawn (spawn)) {
				Spawn (spawn);
			}
		}
	}

	void Spawn (GameObject spawner)
	{
		GameObject spawn = Instantiate (spawner);	
		spawn.transform.parent = transform;
		spawn.transform.position = transform.position;
	}

	private bool IsTimeToSpawn (GameObject spawn)
	{
		Attacker attacker = spawn.GetComponent<Attacker> ();

		float spawnDelay = attacker.SeenEverySeconds;
		float spawnsPerSecond = 1 / spawnDelay;

		if (Time.deltaTime > spawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate.");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		return Random.value < threshold;
	}
}
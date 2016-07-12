using UnityEngine;

[RequireComponent (typeof(Animator))]

public class Thrower : MonoBehaviour
{
	public float FireRate = 0.5f;
	public GameObject Projectile;

	private Animator animator;
	private GameObject ProjectileContainer;
	private Transform Gun;
	private Spawner Lane;

	public void ThrowProjectile ()
	{
		GameObject projectile = Instantiate (Projectile);	

		projectile.transform.parent = ProjectileContainer.transform;
		projectile.transform.position = Gun.position;	
	}

	void Start ()
	{
		animator = GetComponent<Animator> ();

		SetProjectilesContainer ();
		SetGunContainer ();
		SetLane ();
	}

	void Update ()
	{
		animator.SetBool ("IsAttacking", IsAttackerInLane ());
	}

	void SetProjectilesContainer ()
	{
		ProjectileContainer = GameObject.Find ("Projectiles");
		if (!ProjectileContainer) {
			ProjectileContainer = Instantiate (new GameObject ("Projectiles"));
		}		
	}

	void SetGunContainer ()
	{
		Gun = transform.FindChild ("Gun");
		if (!Gun) {
			Gun = Instantiate (new GameObject ("Gun"), transform.position, Quaternion.identity) as Transform;
			Gun.parent = transform.parent;
		}
	}

	void SetLane ()
	{
		GameObject spawnContainer = GameObject.Find ("Spawners");
		if (!spawnContainer) {
			throw new MissingReferenceException ("Can't find the 'Spawners' Container.");
		}

		foreach (Transform spawner in spawnContainer.transform) {
			if (Mathf.Approximately (spawner.position.y, transform.position.y)) {
				Lane = spawner.gameObject.GetComponent<Spawner> ();
				break;
			}
		}
	}

	bool IsAttackerInLane ()
	{
		if (Lane.transform.childCount == 0) {
			return false;
		}

		foreach (Transform attacker in Lane.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}

		return false;
	}
}

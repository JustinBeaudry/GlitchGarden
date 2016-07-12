using UnityEngine;

public class Health : MonoBehaviour
{
	public float HP = 10f;

	protected void Update ()
	{
		HP = Mathf.Clamp (HP, 0, Mathf.Infinity);

		if (Mathf.Approximately (HP, 0f)) {
			Destroy (gameObject);
		}
	}

	public void Damage (float damage)
	{
		HP -= damage;
	}
}

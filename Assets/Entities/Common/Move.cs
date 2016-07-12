using UnityEngine;

public class Move : MonoBehaviour
{
	public float Speed;
	public Vector3 Direction;

	protected void Update ()
	{
		transform.Translate (Direction * Speed * Time.deltaTime);
	}

	public void SetSpeed (float speed)
	{
		Speed = speed;
	}

	public void SetDirection (Vector3 direction)
	{
		Direction = direction;
	}
}

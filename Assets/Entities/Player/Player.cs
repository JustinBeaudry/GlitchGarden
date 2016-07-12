using UnityEngine;

public class Player : MonoBehaviour
{
	public static int DEFAULT_STARS = 8;
	public static int Stars = DEFAULT_STARS;

	public static void AddStars (int amount)
	{
		Stars += amount;
	}

	public static bool UseStars (int amount)
	{
		if (amount > Stars) {
			return false;
		}	

		Stars -= amount;

		return true;
	}
}

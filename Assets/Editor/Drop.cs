using UnityEngine;
using UnityEngine.EventSystems;

public class Drop: MonoBehaviour, IDropHandler
{

	public void OnDrop (PointerEventData data)
	{
		if (data.pointerDrag != null) {
			print ("Dropped object was: " + data.pointerDrag);
		}	
	}
}


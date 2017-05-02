using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	public float interactRange = 3f;
	public bool debugRay = false;
	public Camera FPSCamera;

	private void Start()
	{
		Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private void Update()
	{
		Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
		RaycastHit hitInfo;
		
		if(debugRay == true)
		{
			Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.yellow);
		}

		if(Input.GetKeyDown(KeyCode.F))
		{
			if (Physics.Raycast(ray, out hitInfo, interactRange))
			{
				if (hitInfo.collider.tag == "WeaponPickup")
				{
					WeaponPickup weaponPickup = hitInfo.collider.GetComponent<WeaponPickup>();
					weaponPickup.Interact();
				}
		
			}
		}
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

	public float interactRange = 3f;
	public bool debugRay = false;
	public Camera FPSCamera;
	public Text interactText;
	public KeyCode interactKey = KeyCode.F;

	private void Start()
	{
		Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private void Update()
	{
		Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
		RaycastHit hitInfo;

		interactText.text = ("[" + interactKey + "] " + "Interact");
		
		if(debugRay == true)
		{
			Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.yellow);
		}

		if(Physics.Raycast(ray, out hitInfo, interactRange))
		{
			if(hitInfo.collider.gameObject.layer == 8)
			{
				interactText.enabled = true;
			}
			else if(hitInfo.collider.gameObject.layer != 8)
			{
				interactText.enabled = false;
			}

			if (Input.GetKeyDown(interactKey))
			{
				if (hitInfo.collider.tag == "WeaponPickup")
				{
					WeaponPickup weaponPickup = hitInfo.collider.GetComponent<WeaponPickup>();
					weaponPickup.Interact();
				}
				else if(hitInfo.collider.tag == "AmmoPickup")
				{
					AmmoPickup ammoPickup = hitInfo.collider.GetComponent<AmmoPickup>();
					ammoPickup.Interact();
				}
			}
		}
		else
		{
			interactText.enabled = false;
		}
	}


}

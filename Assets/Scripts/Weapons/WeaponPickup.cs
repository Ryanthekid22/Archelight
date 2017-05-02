using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

	public string weaponName = "PM";
//public string pickupName = "PM";

	private GameObject weaponManager;

	private void Start()
	{
		weaponManager = GameObject.FindGameObjectWithTag("WeaponManager");
	}

	public void Interact()
	{
		GameObject weaponFound = weaponManager.transform.FindChild(weaponName).gameObject;
		weaponFound.SetActive(true);
		Destroy(gameObject);
	}
}

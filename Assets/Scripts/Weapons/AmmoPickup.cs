using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

	public string weaponName = "PM";
	private GameObject weaponManager;
	private ShootingSystem shootingSystem;
	public int ammoAmount = 30;

	private void Start () 
	{
		weaponManager = GameObject.FindGameObjectWithTag("WeaponManager");	
	}

	public void Interact()
	{
		GameObject weaponFound = weaponManager.transform.FindChild(weaponName).gameObject;
		shootingSystem = weaponFound.GetComponent<ShootingSystem>();
		shootingSystem.reserveAmmo += ammoAmount;
		Destroy(gameObject);
	}

}

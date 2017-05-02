using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	public Item item;
	public Item item2;
	private Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = FindObjectOfType<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("t")) {
			Debug.Log("adding test item");
			inventory.AddItem (item);
		}
		if (Input.GetKeyDown ("r")) {
			Debug.Log("removing test item");
			inventory.RemoveItem(item);
		}
		if (Input.GetKeyDown ("y")) {
			Debug.Log("adding test item");
			inventory.AddItem (item2);
		}
		if (Input.GetKeyDown ("u")) {
			Debug.Log("removing test item");
			inventory.RemoveItem(item2);
		}
	}
}

using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour {

	public int minDamage = 25;
	public int maxDamage = 50;
	public float weaponRange = 3.5f;
	
	public Camera FPSCamera;
	
	private TreeHealth treeHealth;
	
	private void Update()
	{
		Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
		RaycastHit hitInfo;
		
		Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.green);
		
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			if(Physics.Raycast(ray, out hitInfo, weaponRange))
			{
				if(hitInfo.collider.tag == "Tree")
				{
					treeHealth = hitInfo.collider.GetComponent<TreeHealth>();
					AttackTree();
				}
			}
		}
	}

	private void AttackTree()
	{
		Debug.Log("Hit Tree" + "Tree Health = " + treeHealth.health);
		int damage = Random.Range(minDamage, maxDamage);
		treeHealth.health -= damage;
	}

}

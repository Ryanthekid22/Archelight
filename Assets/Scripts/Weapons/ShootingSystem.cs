using UnityEngine;
using System.Collections;

public class ShootingSystem : MonoBehaviour {

	public float weaponRange = 100f;
	public Camera FPSCamera;
	public int minDamage = 15;
	public int maxDamage = 30;
	private PauseManager pauseManager;
	private Player player;

	public float aimSpeed = 2;
	public GameObject weaponObject;

	public  Vector3 normalPosition;
	public Vector3 aimingPosition;

	public float recoilAmount = 2;

	public AudioClip gunShotClip;
	private AudioSource audSource;

	public bool isAiming = false;

	private void Start()
	{
		pauseManager = GameObject.FindGameObjectWithTag("PauseManager").GetComponent<PauseManager>();
		audSource = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private Target target;

	private void Update()
	{
		Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
		RaycastHit hitInfo;
		Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.green);

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{	
			if(pauseManager.isPaused == false && player.isDead == false)
			{
				audSource.PlayOneShot(gunShotClip);

			Vector3 weaponObjectLocalPosition = weaponObject.transform.localPosition;
			weaponObjectLocalPosition.z = weaponObjectLocalPosition.z - recoilAmount;
			weaponObject.transform.localPosition = weaponObjectLocalPosition;

			if (Physics.Raycast(ray, out hitInfo, weaponRange))
			{
				if (hitInfo.collider.tag == "Target")
				{
					target = hitInfo.collider.GetComponent<Target>();
					AttackTarget();
				}
			}
			}
			
		}

		if(Input.GetKey(KeyCode.Mouse1))
		{
			isAiming = true;
		}
		else if(!Input.GetKey(KeyCode.Mouse1))
		{
			isAiming = false;
		}

	}

	private void FixedUpdate()
	{
		if(isAiming == true)
		{
			weaponObject.transform.localPosition = Vector3.Lerp(weaponObject.transform.localPosition, aimingPosition, Time.deltaTime * aimSpeed);
		}
		else if (isAiming == false)
		{
			weaponObject.transform.localPosition = Vector3.Lerp(weaponObject.transform.localPosition, normalPosition, Time.deltaTime * aimSpeed);
		}
	}
 
	private void AttackTarget()
	{
		Debug.Log("Hit Target" + "target Health = " + target.health);
		int damage = Random.Range(minDamage, maxDamage);
		target.health -= damage;
	}
}

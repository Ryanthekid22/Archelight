using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class ShootingSystem : MonoBehaviour {

	public float weaponRange = 50f;
	public Camera FPSCamera;

	public int minDamage = 15;
	public int maxDamage = 30;

	private PauseManager pauseManager;
	private Player player;
	public GameObject weaponObject;

	public  Vector3 normalPosition;
	public Vector3 aimingPosition;

	public float recoilAmount = 2;

	public AudioClip gunShotClip;
	private AudioSource audSource;

	private VignetteAndChromaticAberration vignette;
	public float vignetteAimIntensity = 0.2f;
	public float vignettespeedMultiplier = 5f;
	public float aimSpeed = 2;
	public float normalFOV;
	public float FOVchange = 15f;
	public float aimingFOV;
	public float FOVspeed = 5f;

	public bool isAiming = false;

	private void Start()
	{
		normalFOV = FPSCamera.fieldOfView;
		aimingFOV = FPSCamera.fieldOfView - FOVchange;
		vignette = FPSCamera.GetComponent<VignetteAndChromaticAberration>();
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
			vignette.intensity = Mathf.Lerp(vignette.intensity, vignetteAimIntensity, Time.deltaTime * vignettespeedMultiplier);
			FPSCamera.fieldOfView = Mathf.Lerp(FPSCamera.fieldOfView, aimingFOV, Time.deltaTime * FOVspeed);
			weaponRange = 200;
		}
		else if (isAiming == false)
		{
			weaponObject.transform.localPosition = Vector3.Lerp(weaponObject.transform.localPosition, normalPosition, Time.deltaTime * aimSpeed);
			vignette.intensity = Mathf.Lerp(vignette.intensity, 0f, Time.deltaTime * vignettespeedMultiplier);
			FPSCamera.fieldOfView = Mathf.Lerp(FPSCamera.fieldOfView, normalFOV, Time.deltaTime * FOVspeed);
			weaponRange = 50;
		}
	}
 
	private void AttackTarget()
	{
		Debug.Log("Hit Target" + "target Health = " + target.health);
		int damage = Random.Range(minDamage, maxDamage);
		target.health -= damage;
	}
}

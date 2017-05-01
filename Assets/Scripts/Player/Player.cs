using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Vector3 spawnPoint = Vector3.zero;
	public GameObject deathCanvas;
	public float health = 100f;
	
	public float hunger = 100f;
	public float thirst = 100f;
	
	public Image healthBar;
	public Image hungerBar;
	public Image thirstBar;
	
	public float hungerSpeedMultiplier = 0.10f;
	public float thirstSpeedMultiplier = 0.25f;
	
	private Blur blur;
	
	
	private void Start()
	{
		blur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>();
		deathCanvas.SetActive(false);
	}
	
	private void Update()
	{
		CheckDeath();
		
		if(hunger > 0)
		{
			hunger -= Time.deltaTime * hungerSpeedMultiplier;
		}
		
		if(thirst > 0)
		{
			thirst -= Time.deltaTime * thirstSpeedMultiplier;
		}
		
		if(hunger <= 0)
		{
			health -= Time.deltaTime * hungerSpeedMultiplier;
		}
		
		if(thirst <= 0)
		{
			health -= Time.deltaTime * thirstSpeedMultiplier;
		}
		
		
		healthBar.fillAmount = health / 100;
		hungerBar.fillAmount = hunger / 100;
		thirstBar.fillAmount = thirst / 100;
	}
	
	private void CheckDeath()
	{
		if(health <= 0)
		{
			Die();
		}
	}
	
	private void Die()
	{
		Time.timeScale = 0.0f;
		deathCanvas.SetActive(true);
		blur.enabled = true;
	}
	
	public void Respawn()
	{
		Time.timeScale = 1.0f;
		deathCanvas.SetActive(false);
		transform.position = spawnPoint;
		health = 100;
		hunger = 100;
		thirst = 100;
		blur.enabled = false;
	}
	public void Suicide()
	{
		health = 0;
	}
}

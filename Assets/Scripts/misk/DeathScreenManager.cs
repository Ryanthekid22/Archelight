using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class DeathScreenManager : MonoBehaviour {

private PauseManager pauseManager;
private Blur blur;
private CursorManager cursorManager;
public GameObject deathCanvas;
private Player player;

private void Start()
	{
	cursorManager = GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>();
	pauseManager = GameObject.FindGameObjectWithTag("PauseManager").GetComponent<PauseManager>();
	blur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>();
	deathCanvas.SetActive(false);
	player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

private void Upadate()
	{
		CheckDeath();
	}

	private void CheckDeath()
	{
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health <= 0)
		{
			Debug.Log("You are dead");
			Die();
		}
	}

	private void Die()
	{
		Time.timeScale = 0.0f;
		deathCanvas.SetActive(true);
		blur.enabled = true;
		cursorManager.ShowUnlockCursor();
		if(pauseManager.isPaused == true)
		{
			pauseManager.isPaused = false;
		}	
	}
	
}

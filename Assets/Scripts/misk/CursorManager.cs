using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class CursorManager : MonoBehaviour {

private PauseManager pauseManager;
public bool isShown;
private Player player;
private Blur blur;

	private void Start()
	{
        blur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>();
		pauseManager = GameObject.FindGameObjectWithTag("PauseManager").GetComponent<PauseManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private void Update()
	{
        if(player.isDead == true)
        {
            ShowUnlockCursor();
            Time.timeScale = 0.0f;
            blur.enabled = true;
        }
		if(pauseManager.isPaused == true)
		{
			ShowUnlockCursor();
            Time.timeScale = 0.0f;
            blur.enabled = true;
		}
		else if(pauseManager.isPaused == false && player.isDead == false)
		{
			HideLockCursor();
            Time.timeScale = 1.0f;
            blur.enabled = false;
		}
    }

	public void HideLockCursor()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void ShowUnlockCursor()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
}

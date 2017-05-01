using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {

private PauseManager pauseManager;

	private void Start()
	{
		pauseManager = GameObject.FindGameObjectWithTag("PauseManager").GetComponent<PauseManager>();
	}

	private void Update()
	{
		if(pauseManager.isPaused == true)
		{
			ShowUnlockCursor();
		}
		else if(pauseManager.isPaused == false)
		{
			HideLockCursor();
		}
    }

	private void HideLockCursor()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void ShowUnlockCursor()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

}

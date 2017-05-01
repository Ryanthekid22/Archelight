using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class PauseManager : MonoBehaviour {
	
	public GameObject pauseCanvas;
	public KeyCode pauseKey = KeyCode.Escape;
	
	public bool isPaused = false;
	
	private Blur blur;
	
	private void Start()
	{
		blur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>();
		
		isPaused = false;
	}
	
	private void Update()
	{
		if(Input.GetKeyDown(pauseKey))
		{
			isPaused = !isPaused;
		}
		if(isPaused == true)
		{

			pauseCanvas.SetActive(true);
			blur.enabled = true;
		}
		else if(isPaused == false)
		{
			pauseCanvas.SetActive(false);
			blur.enabled = false;
		}
	}
	
	public void ResumeGame()
	{
		isPaused = false;
	}
	
	public void ExitGame()
	{
		Debug.Log("Quiting");
		Application.Quit();
	}
	
}

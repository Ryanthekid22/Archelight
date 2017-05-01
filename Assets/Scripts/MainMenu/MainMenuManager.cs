using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
		Debug.Log("LOADING");
	}

	public void ExitGame()
	{
		Application.Quit();
		Debug.Log("Exiting");
	}

}

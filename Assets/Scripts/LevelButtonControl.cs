using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonControl : MonoBehaviour {
	
	public int iDPortal;
	public int numbOfCoins;
	public int numbOfEnemiesToSave;
	public int numbOfItemCoins;
	public int numbOfItemMM;
	public int numbOfItemLM;
	public int currentScore;
	public string levelToLoad;

	public GameController gameC;
	public GameObject canvasACargar;
	public GameObject canvasASalir;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("CurrentScore", currentScore);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void LoadLevel(){
		PlayerPrefs.SetInt ("IDPORTAL", iDPortal);
		PlayerPrefs.SetInt ("NumbOfCoins", numbOfCoins);
		PlayerPrefs.SetInt ("NumbOfEnemies", numbOfEnemiesToSave);
		PlayerPrefs.SetInt ("NumbOfItemCoins", numbOfItemCoins);
		PlayerPrefs.SetInt ("NumbOfItemMM", numbOfItemMM);
		PlayerPrefs.SetInt ("NumbOfItemLM", numbOfItemLM);
		PlayerPrefs.SetInt ("CurrentScore", currentScore);
		SceneManager.LoadScene (levelToLoad);
		Time.timeScale = 1;
	}
	public void PrintPortalLevels(){
		canvasACargar.SetActive (true);
		canvasASalir.SetActive (false);
		//gameC.Carge ();
	}

	public void QuitMenu(){
		canvasASalir.SetActive (false);
		Time.timeScale = 1;
	}


	//public void SalirPortalLevels(){
	//	print ("adios xdd");
	//}
}

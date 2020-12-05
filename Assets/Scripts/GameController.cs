using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
	//Puntaje
	[Header("Puntaje")]
	public Text currentScoreText;
	public int currentScore = 0;
	//Monedas
	[Header("Monedas")]
	public Text currentCoinsText;
	public int currentCoins;
	public CoinGeneratorControl listCoins;
	//Movimiento
	[Header("Movimento")]
	public Text currentMovText;
	public float currentMov;
	//Enemigos
	[Header("Enemigos")]
	public Text currentNroEnemyText;
	public int currentNroEnemy;
	public EnemyGeneratorControl listEnemy;
	[Header("Item Coins")]
	public Text currentItemsCoinsText;
	public int currentItemCoins;

	[Header("Item MM")]
	public Text currentItemsMMText;
	public int currentItemMM;

	[Header("Item LM")]
	public Text currentItemsLMText;
	public int currentItemLM;
	public ItemsGeneratorControl listItems;

	[Header("Other Variables")]
	public PlayerControl player;
	public GameObject gameOverText;
	public GameObject canvasProtal;
	public bool gameOver;
	private bool pause= false;

	public void Awake(){
			//Main del main
	
	}

	void Start () {
	//	CreateColumn ();
		NumberCoins();
		NumberEnemys ();
		NumberItemsLM ();
		NumberItemsMM ();
		NumberItemsCoins ();

	}	
	
	// Update is called once per frame
	void Update () {
		if (gameOver && Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene ("TF-1.1");
			pause = false;
			//GamePause ();
			//Time.timeScale = 0;
		}
		if(Input.GetKeyDown(KeyCode.P) && pause==false){
			pause = true;
			//GamePause ();
			Time.timeScale = 0;
		}
		else if(Input.GetKeyDown(KeyCode.P) && pause==true){
			pause= false;
			Time.timeScale = 1;
		}
	}

	public void IncreaseScore(int scoreToAdd){
		currentScore = currentScore + scoreToAdd;
		currentScoreText.text = "Puntaje: " + currentScore.ToString ();
	}

	public void NumberCoins(){
		currentCoins = listCoins.getNumberCoins ();
		currentCoinsText.text = "Monedas: " + currentCoins.ToString ();
	}
	public void NumberEnemys(){
		currentNroEnemy	 = listEnemy.getNumberEnemies ();
		currentNroEnemyText.text = "Enemigos: " + currentNroEnemy.ToString ();
	}
	public void NumberItemsCoins(){
		currentItemCoins = listItems.getNumberItemCoins ();
		currentItemsCoinsText.text = "Items Coins: " + currentItemCoins.ToString ();
	}
	public void NumberItemsMM(){
		currentItemMM = listItems.getNumberItemMM ();
		currentItemsMMText.text = "Items MM: " + currentItemMM.ToString ();
	}
	public void NumberItemsLM(){
		currentItemLM = listItems.getNumberItemLM ();
		currentItemsLMText.text = "Items LM: " + currentItemLM.ToString ();
	}
	public void CallPortal(){
		canvasProtal.SetActive (true);
		Time.timeScale = 0;
	}

	public void BirdDie(){
		gameOverText.SetActive (true);
		gameOver = true;
	}

}

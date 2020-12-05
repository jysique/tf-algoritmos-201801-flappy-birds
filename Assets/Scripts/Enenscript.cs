using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enenscript : MonoBehaviour {
	private Animator animEnemy;
	private Rigidbody2D bodyEnemy;
	private EnemyGeneratorControl enemyGenerator;
	public GameController gameController;
	public int enemyValue;
	// Use this for initialization
	void Start () {
		bodyEnemy = GetComponent<Rigidbody2D>();
		animEnemy = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movEnemy = new Vector2 (-0.3f, 0);
		bodyEnemy.velocity = movEnemy;
		animEnemy.SetTrigger ("Up");
	}
	public void SetEnemyGeneratorControl(EnemyGeneratorControl tmp){
		enemyGenerator = tmp;
	}
	public void SendDestroy(){
		enemyGenerator.DestroyEnemy (this.gameObject);
	}
	public void HitEnemy(){
		gameController.IncreaseScore (enemyValue);
	}
	public void setGameManager(GameController tmp){
		gameController = tmp;
	}
}

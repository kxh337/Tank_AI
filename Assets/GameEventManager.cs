using UnityEngine;
using System.Collections;

public class GameEventManager : MonoBehaviour {
	private static bool loseCon = false;
	private static bool winCon = false;
	public static int enemies;
	public static int allies;
	public static int difficulty = 1;

	public static void playerDeath() {
		loseCon = true;
	}

	public static void tankDeath(string team) {
		if (team.Equals ("Enemy")) {
			enemies--;
		}
		else
			allies--;
		if (allies <= 0 && !winCon) {
			GameEventManager.loseCon = true;
		}
		if (enemies <= 0 && !loseCon) {
			GameEventManager.winCon = true;
		}
	}

	void OnGUI() {
		if (loseCon) {
			if (GUI.Button(new Rect(10, 10, 150, 100), "You Lost!\nReturn to Main Menu?")) {
				Application.LoadLevel(0);
				loseCon = false;
			}
		}
		if (winCon) {
			if (GUI.Button(new Rect(10, 10, 150, 100), "You Won!\nReturn to Main Menu?")) {
				winCon = false;
				Application.LoadLevel (0);
			}
			if (GUI.Button(new Rect(250, 10, 150, 100), "I want more\nof a Challenge!")){
				difficulty = 2;
				winCon = false;
				Application.LoadLevel (1);
			}
			if (GUI.Button(new Rect(400, 10, 150, 100), "I want to\nfeel the burn!")){
				difficulty = 3;
				winCon = false;
				Application.LoadLevel (1);
			}
			if (GUI.Button(new Rect(250, 110, 150, 100), "I hate my\nown happiness")){
				difficulty = 4;
				winCon = false;
				Application.LoadLevel (1);
			}
			if (GUI.Button(new Rect(400, 110, 150, 100),"This game is\nnow my life.")){
				difficulty = 5;
				winCon = false;
				Application.LoadLevel (1);
			}
		}
	}

	// Use this for initialization
	void Start () {
		enemies = 4;
		allies = 3;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

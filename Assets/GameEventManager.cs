using UnityEngine;
using System.Collections;

/*
 * handles game events including deaths, winning, and losing
 * also the only way to change difficulty
 */

public class GameEventManager : MonoBehaviour {
	private static bool loseCon = false; // if the game is lost
	private static bool winCon = false; // if the game is won
	public static int enemies; // number of enemies
	public static int allies; // number of allies
	public static int difficulty = 1; // difficulty setting
	public AudioClip victory; // win sound

	/*
	 * forces game loss if palyer dies
	 */
	public static void playerDeath() {
		loseCon = true;
	}

	/*
	 * notes AI death and checks win/lose conditions
	 * @param team the tag of the tank that dies
	 */
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

	/*
	 * buttons for the win/lose screens
	 */
	void OnGUI() {
		if (loseCon) {
			if (GUI.Button(new Rect(10, 10, 150, 100), "You Lost!\nReturn to Main Menu?")) {
				Application.LoadLevel(0);
				loseCon = false;
			}
		}
		if (winCon) {
			audio.PlayOneShot(victory);
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

	// initializes team sizes, currently no need for dynamic counting
	void Start () {
		enemies = 4;
		allies = 3;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

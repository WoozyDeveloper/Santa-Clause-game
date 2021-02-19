using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoreGetter : MonoBehaviour {

    public Text highText;
	// Use this for initialization
	void Start () {
        highText.text = "Your highscore: " + PlayerPrefs.GetInt("LevelHardScore");

    }
// Update is called once per frame
void Update () {
		
	}
}

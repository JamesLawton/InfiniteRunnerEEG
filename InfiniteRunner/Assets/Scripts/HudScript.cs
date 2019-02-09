using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour {

    public float playerScore;
    int playedTime;

    private void Awake()
        {
            playerScore = 0;
            
        }
	
	// Update is called once per frame
	void Update () {
        playerScore += Time.deltaTime;
        //playedTime = playerScore / 60f;
	}
    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", (int)playerScore);
        PlayerPrefs.SetFloat("Time", playerScore);
    }

    void OnGUI()
    {
        var TextStyle = new GUIStyle();
        TextStyle.normal.textColor = Color.yellow;
        TextStyle.fontSize = 30;
        //GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(playerScore));
        GUI.Label(new Rect(10, 10, 100, 30), "Time: " + playerScore.ToString("F2")+"\n \n Highscore: \n Raja:\t 31.45 \n James:\t 31.59 \n Chris:\t 32.14 \n Nico:\t 32.21", TextStyle);
    }
}

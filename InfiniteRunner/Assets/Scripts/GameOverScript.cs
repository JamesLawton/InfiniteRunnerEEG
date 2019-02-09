using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    int score = 0;
    float time =0f;
	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("Score");
        time = PlayerPrefs.GetFloat("Time");
	}

    void OnGUI()
    {
        var TextStyle = new GUIStyle();
        TextStyle.normal.textColor = Color.red;
        TextStyle.fontSize = 50;

        var TextStyle2 = new GUIStyle();
        TextStyle2.normal.textColor = Color.yellow;
        TextStyle2.fontSize = 40;

        var TextStyle3 = new GUIStyle();
        TextStyle3.normal.textColor = Color.yellow;
        TextStyle3.fontSize = 20;

        GUI.Label(new Rect(Screen.width / 2 - 130, 50, 80, 30), "GAME OVER",TextStyle);
        GUI.Label(new Rect(Screen.width / 2 - 90, 200, 80, 30), "Time: " + time.ToString("F2"), TextStyle2);

        GUI.Label(new Rect(Screen.width / 2 - 70, 300, 100, 130), "\n \n Highscore: \n Raja:\t 31.45 \n James:\t 31.59 \n Chris:\t 32.14 \n Nico:\t 32.21 \n",TextStyle3);
        

        if(GUI.Button(new Rect(Screen.width / 2 - 30,500,60,30), "Retry?"))
        {
            //Application.LoadLevel(0);
            SceneManager.LoadScene(0);
        }
    }

}


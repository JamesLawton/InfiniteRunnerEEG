using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System.Text;

public class EvaluationRestartScript : MonoBehaviour
{

    // Use this for initialization


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var actorJumpData = other.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().jumpData;
            string json = JsonUtility.ToJson(actorJumpData);
            string path = Application.dataPath + "/JumpData/JumpData.txt";
            Debug.Log("AssetPath:" + path);
            StreamWriter writer = new StreamWriter(path, true);
            writer.Write(json + "\n");
            writer.Close();

            var hud = GameObject.Find("Main Camera").GetComponent<HudScript>();
            string playerTime = hud.playerScore.ToString();
            string path2 = Application.dataPath + "/JumpData/TimeData.txt";
            Debug.Log("AssetPath:" + path);
            StreamWriter writer2 = new StreamWriter(path2, true);
            writer2.Write(playerTime + ", \n");
            writer2.Close();


            SceneManager.LoadScene(2);
            return;
        }
    }
}
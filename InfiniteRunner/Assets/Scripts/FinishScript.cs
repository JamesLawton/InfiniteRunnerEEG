using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

public class FinishScript : MonoBehaviour
{

    // Use this for initialization
    public AudioClip hitGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(hitGoal,this.transform.position);


            // save jumpdata to json file
            var actorJumpData = other.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().jumpData;
            string json = JsonUtility.ToJson(actorJumpData);
            string path = Application.dataPath + "/JumpData/JumpData.txt";
            Debug.Log ("AssetPath:" + path);
            StreamWriter writer = new StreamWriter(path, true);
            writer.Write(json+"\n");
            writer.Close();
            //Re-import the file to update the reference in the editor
            //AssetDatabase.ImportAsset(path); 
            //TextAsset asset = Resources.Load("JumpData.json");

            //Print the text from the file
            //Debug.Log(asset.text);
         //}
     //}
            //UnityEditor.AssetDatabase.Refresh ();

            StartCoroutine(waitshortly());

            
            //SceneManager.LoadScene(1);
            return;
        }
    }
    public IEnumerator waitshortly()
        {          
            
            yield return new WaitForSeconds(1);
            Application.LoadLevel(1);   
        }
}
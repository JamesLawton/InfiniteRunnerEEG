using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour {

    HudScript hud;

    public int powerupID;

    private void OnTriggerEnter2D(Collider2D other)
 

    {
        if (other.tag == "Player")
        {
            
            print("Powerup was hit by the player");
            other.gameObject.SendMessage("HitPowerup");
            hud = GameObject.Find("Main Camera").GetComponent<HudScript>();
            

            // add this powerupID to the Agent-List
            var actorJumpData = other.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().jumpData;

            actorJumpData.CollectedPowerUps.Add(powerupID);
            actorJumpData.CollectedPowerUps.Add(hud.playerScore);
            Destroy(this.gameObject);
            //print(actorJumpData.CollectedPowerUps.ToString());
            //foreach (int item in actorJumpData.CollectedPowerUps) { print (actorJumpData.CollectedPowerUps[item]); }
            

        }
    }

}

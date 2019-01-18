using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour {

    HudScript hud;

    private void OnTriggerEnter2D(Collider2D other)
 

    {
        if (other.tag == "Player")
        {
            print("Powerup was hit by the player");
            other.gameObject.SendMessage("HitPowerup");
            hud = GameObject.Find("Main Camera").GetComponent<HudScript>();
            Destroy(this.gameObject);
        }
    }

}

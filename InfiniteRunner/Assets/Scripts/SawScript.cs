using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity.Scripts.Examples;


    public class SawScript : MonoBehaviour
    {

        //public PlatformerCharacter2D m_Character;
        public int sawID;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
            print("Saw was hit by the player");
            other.gameObject.SendMessage("HitSaw");

            // add this powerupID to the Agent-List
            var actorJumpData = other.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().jumpData;
            Destroy(this.gameObject);
            actorJumpData.CollectedSaws.Add(sawID);


            
            //foreach (int item in actorJumpData.CollectedSaws) { print (actorJumpData.CollectedSaws[item]); }
        }
        }
    }


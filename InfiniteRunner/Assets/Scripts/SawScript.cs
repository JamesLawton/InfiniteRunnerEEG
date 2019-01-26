using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity.Scripts.Examples;


    public class SawScript : MonoBehaviour
    {

        //public PlatformerCharacter2D m_Character;


        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
            print("Saw was hit by the player");
            other.gameObject.SendMessage("HitSaw");
            Destroy(this.gameObject);

        }
        }
    }


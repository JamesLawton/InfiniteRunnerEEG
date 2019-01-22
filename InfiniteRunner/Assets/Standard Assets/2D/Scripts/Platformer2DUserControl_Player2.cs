using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity.Scripts.Examples;
using System.Collections;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D_Player2))]
    public class Platformer2DUserControl_Player2 : MonoBehaviour
    {

        //Provide variables for EEG in player controller for respective game
        private PlatformerCharacter2D_Player2 m_Character;
        private bool m_Jump;
        private Player2FloatInlet inlet;
        private bool crouch;




        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D_Player2>();
            inlet = FindObjectOfType<Player2FloatInlet>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // if (inlet.lastSample.Length > 0)
               // if (inlet.lastSample[0] > 1.5)
               // {
                //    m_Jump = true;
                    
               // }

                    // Read the jump input in Update so button presses aren't missed.
                    //uncomment for space bar below
                    //m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }

        public void HitSaw ()
        {
            m_Character.DecreaseSpeed();
        }

        public void HitPowerup()
        {
            StartCoroutine(m_Character.IncreaseSpeed());
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            Console.WriteLine(inlet.lastSample.Length);
            //uncomment crouch for EEG
            bool crouch = Input.GetKey(KeyCode.LeftControl);

        //    if (inlet.lastSample.Length < 0)
        //    {
        //        crouch = true;
        //    }
        //    else
        //    {
        //        crouch = false;
        //    }
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.





            m_Character.Move(1, crouch, m_Jump);
            m_Jump = false;
        }
    }
}

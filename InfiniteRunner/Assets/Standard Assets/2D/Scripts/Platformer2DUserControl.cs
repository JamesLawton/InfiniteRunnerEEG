using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity.Scripts.Examples;
using System.Collections;
using System.Collections.Generic;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {

        //Provide variables for EEG in player controller for respective game
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private ExampleFloatInlet inlet;
        private bool crouch;
        public AudioClip[] hitSawSound;
        public AudioClip[] hitPowerupSound;

        public ActorJumpData jumpData;
        
        public int numberJumps;
        public bool jumpBool;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            inlet = FindObjectOfType<ExampleFloatInlet>();
            jumpData = new ActorJumpData();
            numberJumps = 0;
        }


        private void Update()
        {
            if (!m_Jump)
            {

                Console.WriteLine(inlet.lastSample.Length);
                //if (inlet.lastSample[0] > 4.1)
                
                //int random_jump = UnityEngine.Random.Range(0,1000);

                
                //if (random_jump > 974) // 989
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_Jump = true;
                    
                    jumpBool = true;
                    //Console.WriteLine(inlet.lastSample.Length);
                }

                    // Read the jump input in Update so button presses aren't missed.
                    //uncomment for space bar below
                    //m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }

        public void HitSaw ()
        {
            StartCoroutine(m_Character.DecreaseSpeed());
            //AudioSource.PlayClipAtPoint(hitSawSound,this.transform.position);
            AudioSource.PlayClipAtPoint(hitSawSound[UnityEngine.Random.Range(0,hitSawSound.Length)],this.transform.position);
        }

        public void HitPowerup()
        {
            StartCoroutine(m_Character.IncreaseSpeed());
            //AudioSource.PlayClipAtPoint(hitPowerupSound,this.transform.position);
            AudioSource.PlayClipAtPoint(hitPowerupSound[UnityEngine.Random.Range(0,hitPowerupSound.Length)],this.transform.position);
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

            if(jumpBool){
                numberJumps += 1;
                jumpBool = false;
            }
            
        }

        
    }

    [Serializable]
    public class ActorJumpData
    {
    //public List<int> CollectedPowerUps = new List<int>();
    //public List<int> CollectedSaws = new List<int>();

    [HideInInspector]
    public List<float> CollectedPowerUps;
    [HideInInspector]
    public List<float> CollectedSaws;

    public ActorJumpData(){
        this.CollectedPowerUps = new List<float>();
        this.CollectedSaws = new List<float>();
    }
    }



}

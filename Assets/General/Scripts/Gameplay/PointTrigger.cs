using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace FlappyBirdClone
{
	public class PointTrigger : MonoBehaviour
	{
        //Ammount of points to add
        public int reward = 1;

        public AudioClip SFX;

        //Audio source is responsible for audio
        AudioSource audioSource;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Unity callback called when ever a 2D trigger is entered by another collider
        /// The collider parameter provides information about the collider that entered this trigger
        /// </summary>
        /// <param name="collider"></param>
        void OnTriggerEnter2D(Collider2D collider)
        {
            //Check if the bird entered this trigger and check if the bird is still alive
            if(collider.gameObject == Game.Instance.Bird.gameObject && Game.Instance.Bird.IsAlive)
            {
                Game.Instance.points += reward;
                audioSource.PlayOneShot(SFX);
            }
        }
	}
}
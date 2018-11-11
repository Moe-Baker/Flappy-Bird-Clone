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

namespace Game
{
    [DefaultExecutionOrder(-1)]
    [RequireComponent(typeof(AudioSource))]
	public class Game : MonoBehaviour
	{
        public static Game Instance { get; private set; }

        public GamePoints Points { get; private set; }

        public Bird Bird { get; private set; }

        public Menu Menu { get; private set; }

        public AudioSource AudioSource { get; private set; }

        public FollowGenerator obstaclesGenerator;

        void Awake()
        {
            Instance = this;

            Points = FindObjectOfType<GamePoints>();

            Bird = FindObjectOfType<Bird>();
            Bird.OnDeath += OnBirdDeath;
            Bird.gameObject.SetActive(false);

            Menu = FindObjectOfType<Menu>();

            AudioSource = GetComponent<AudioSource>();
        }

        public void Begin()
        {
            Menu.start.SetActive(false);
            Menu.HUD.SetActive(true);

            Bird.transform.position = Vector3.zero;

            if(!Bird.IsAlive)
                Bird.Revive();

            Bird.gameObject.SetActive(true);

            obstaclesGenerator.Clear();
        }

        void OnBirdDeath()
        {
            Invoke("OnEnd", 2f);
        }

        void OnEnd()
        {
            Menu.HUD.SetActive(false);

            Menu.end.SetActive(true);
        }
        
        public void Reset()
        {
            Menu.start.SetActive(true);
            Menu.HUD.SetActive(false);
            Menu.end.SetActive(false);

            Points.Clear();
        }
    }
}
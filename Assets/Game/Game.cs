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

        public Bird Bird { get; private set; }

        public GamePoints Points { get; private set; }

        public AudioSource AudioSource { get; private set; }

        void Awake()
        {
            Instance = this;

            Bird = FindObjectOfType<Bird>();

            Points = FindObjectOfType<GamePoints>();

            AudioSource = GetComponent<AudioSource>();
        }
	}
}
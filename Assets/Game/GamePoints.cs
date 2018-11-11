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
	public class GamePoints : MonoBehaviour
	{
        [SerializeField]
        int value;
        public int Value { get { return value; } }

        public AudioClip gainSound;
        public void Add(int increase)
        {
            value += increase;

            Game.Instance.AudioSource.PlayOneShot(gainSound);
        }
	}
}
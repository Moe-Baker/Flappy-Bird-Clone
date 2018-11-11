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
    [RequireComponent(typeof(Text))]
	public class PointsLabel : MonoBehaviour
	{
        Text label;

        public string prefix;

        void Start()
        {
            label = GetComponent<Text>();
        }

        void Update()
        {
            label.text = prefix + Game.Instance.Points.Value.ToString();
        }
	}
}
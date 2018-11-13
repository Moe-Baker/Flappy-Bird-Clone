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
    ///Attribute used to designate that another component of a certian type is required for this component to work
    ///That designated component will be auto added when this component is added to a gameobject
    [RequireComponent(typeof(Text))]
	public class PointsLabel : MonoBehaviour
	{
        Text label;

        //Prefix to add before the score
        public string prefix;

        void Start()
        {
            label = GetComponent<Text>();
        }

        void Update()
        {
            label.text = prefix + Game.Instance.points;
        }
	}
}
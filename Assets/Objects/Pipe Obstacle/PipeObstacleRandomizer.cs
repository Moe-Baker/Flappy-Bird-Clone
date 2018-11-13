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
    //Attribute used to designate that another component of a certian type is required for this component to work
    ///That designated component will be auto added when this component is added to a gameobject
    [RequireComponent(typeof(PipeObstacle))]
    //Randomizes the obstacles size and offset (Y position)
	public class PipeObstacleRandomizer : MonoBehaviour
	{
        public float minSize;
        public float maxSize;

        [Space]
        public float minOffset;
        public float maxOffset;

        void Start()
        {
            var obstacle = GetComponent<PipeObstacle>();

            obstacle.SetSize(UnityEngine.Random.Range(minSize, maxSize));

            var position = obstacle.transform.localPosition;
            position.y = UnityEngine.Random.Range(minOffset, maxOffset);
            obstacle.transform.localPosition = position;
        }
	}
}
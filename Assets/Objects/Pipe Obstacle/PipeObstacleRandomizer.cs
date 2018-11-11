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
    [RequireComponent(typeof(PipeObstacle))]
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
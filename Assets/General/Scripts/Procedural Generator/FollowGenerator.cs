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
    [RequireComponent(typeof(ContinuousGenerator))]
	public class FollowGenerator : MonoBehaviour
	{
        ContinuousGenerator continuousGenerator;

        public Transform target;

        public float offset;

        Queue<GameObject> instances = new Queue<GameObject>();
        public void Clear()
        {
            continuousGenerator.ResetIndex();

            while(instances.Count > 0)
            {
                Destroy(instances.Peek());
                instances.Dequeue();
            }
        }

        void Start()
        {
            continuousGenerator = GetComponent<ContinuousGenerator>();
        }

        void Update()
        {
            while(target.position.x + offset > continuousGenerator.IndexPosition.x)
            {
                instances.Enqueue(continuousGenerator.Create());
            }
        }
    }
}
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
	public class ProceduralGenerator : MonoBehaviour
	{
        public GameObject prefab;

        public float space;

        List<GameObject> instances = new List<GameObject>();

        public int length = 100;

        void Awake()
        {
            Reset();
        }

        public GameObject Create(Vector3 position)
        {
            var instance = Instantiate(prefab, position, Quaternion.identity);

            instance.transform.SetParent(transform);

            return instance;
        }

        public void Reset()
        {
            for (int i = 0; i < instances.Count; i++)
                Destroy(instances[i]);

            instances.Clear();

            for (int i = 0; i < length; i++)
                instances.Add(Create(transform.position + Vector3.right * i * space));
        }
    }
}
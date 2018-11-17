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

        public Transform followTarget;
        public float followRange = 20f;

        List<GameObject> instances = new List<GameObject>();

        void Awake()
        {
            Reset();
        }

        public void Reset()
        {
            foreach (var instance in instances)
                Destroy(instance);

            instances.Clear();

            for (int i = 0; i < 6f; i++)
            {
                var instance = Create(transform.position + Vector3.right * i * space);

                instances.Add(instance);
            }
        }

        void Update()
        {
            for (int i = instances.Count; i-- > 0;)
            {
                if (instances[i].transform.position.x < followTarget.position.x - followRange)
                {
                    var instance = instances[i];

                    instance.transform.position = instances.Last().transform.position + Vector3.right * space;
                    instance.SendMessage("OnRegeneration", SendMessageOptions.DontRequireReceiver);

                    instances.RemoveAt(i);
                    instances.Add(instance);
                }
            }
        }

        public GameObject Create(Vector3 position)
        {
            var instance = Instantiate(prefab, position, Quaternion.identity);

            instance.transform.SetParent(transform);

            return instance;
        }
    }
}
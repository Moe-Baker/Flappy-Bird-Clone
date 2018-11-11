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
    [RequireComponent(typeof(ProceduralGenerator))]
	public class ContinuousGenerator : MonoBehaviour
	{
        ProceduralGenerator proceduralGenerator;

        void Awake()
        {
            proceduralGenerator = GetComponent<ProceduralGenerator>();

            indexPosition = transform.position;

            for (int i = 0; i < 100; i++)
                Create();
        }

        public float offset;
        int index = 0;
        Vector2 indexPosition;
        public void Create()
        {
            var instance = proceduralGenerator.Create(indexPosition);

            index++;
            indexPosition += Vector2.right * offset;
        }
    }
}
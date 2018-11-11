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
	public class ProceduralGenerator : MonoBehaviour
	{
        public GameObject prefab;

        public GameObject Create(Vector3 position)
        {
            var instance = Instantiate(prefab, position, Quaternion.identity);

            instance.transform.SetParent(transform);

            return instance;
        }
	}
}
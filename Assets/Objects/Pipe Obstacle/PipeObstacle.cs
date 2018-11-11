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
    [ExecuteInEditMode]
	public class PipeObstacle : MonoBehaviour
	{
        public Transform top;
        public Transform bottom;

        [SerializeField]
        float size;
        public void SetSize(float value)
        {
            size = value;

            if (top != null)
                top.localPosition = Vector3.up * value / 2;

            if (bottom != null)
                bottom.localPosition = Vector3.down * value / 2;
        }

        void Start()
        {
            SetSize(size);
        }

        void Update()
        {
            if (!Application.isPlaying)
                SetSize(size);
        }
    }
}
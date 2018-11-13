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
    ///Allows Unity's callbacks to be called while in edit mode (when the game isn't being played)
    ///Normally those callbacks would've been called only when the game starts (after hitting the play button)
    [ExecuteInEditMode]
	public class PipeObstacle : MonoBehaviour
	{
        //top part of the obstacle
        public Transform top;

        //bottom part of the obstacle
        public Transform bottom;

        [SerializeField]
        //represents the size of the gap of the obstacle
        float size;
        public void SetSize(float value)
        {
            size = value;

            ///Check if the parts are assigned
            ///And modify their local position (position relative to their parent)

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
            if (Application.isEditor) //Continously apply the size when in the editor
                SetSize(size);
        }
    }
}
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
	public class FollowCamera : MonoBehaviour
	{
        public Bird bird;

        void Update()
        {
            if(bird.IsAlive)
            {
                var position = transform.position;
                position.x = bird.transform.position.x;
                transform.position = position;
            }
        }
	}
}
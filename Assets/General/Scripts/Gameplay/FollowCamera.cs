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
	public class FollowCamera : MonoBehaviour
	{
        public Bird Bird { get { return Game.Instance.Bird; } }

        void Update()
        {
            if(Bird.IsAlive)
            {
                var position = transform.position;
                position.x = Bird.transform.position.x;
                transform.position = position;
            }
        }
	}
}
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
                ///Retrieve the transform's position because we can't modify its internals directly
                ///So "transform.position.x = 20" isn't allowed because of how C# works
                var position = transform.position;

                //Follow the Bird on the X Axis only
                position.x = Bird.transform.position.x;

                //Apply the position back
                transform.position = position;
            }
        }
	}
}
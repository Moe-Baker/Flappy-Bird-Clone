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
    /// <summary>
    /// Component to keep track of the menu elements
    /// </summary>
	public class Menu : MonoBehaviour
	{
        //The start menu, the first menu the player sees
        public GameObject start;

        ///The game's Head-Up Display (HUD)
        ///Contains any gameplay specific information (Coins Label)
        public GameObject HUD;

        //The end screen of the game
        public GameObject end;
    }
}
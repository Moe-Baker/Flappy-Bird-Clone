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
    /// Controls the order at which Unity's callbacks (Awake, Start, Update) are called
    /// Needed to ensure that all references are set before any external script tries to access them
    /// </summary>
    [DefaultExecutionOrder(-1)]
    ///Controls the entire game behaviour, all the way from starting a game, saving points and ending a game
	public class Game : MonoBehaviour
	{
        //static (global) accessor to the Game class, is used to access this instance of the game from anywhere
        public static Game Instance { get; private set; }

        public int points = 0;

        public Bird Bird { get; private set; }

        public Menu Menu { get; private set; }

        public ProceduralGenerator obstaclesGenerator;

        void Awake()
        {
            //Set static instance to "this" = a reference to the current component instance
            Instance = this;

            //Find Bird within the local scene
            Bird = FindObjectOfType<Bird>();
            //Listen in to the bird death event
            Bird.OnDeath += OnBirdDeath;
            //Disable the bird gameobject (hide it)
            Bird.gameObject.SetActive(false);

            //Find the Menu component
            Menu = FindObjectOfType<Menu>();
        }

        public void Begin()
        {
            Menu.start.SetActive(false);
            Menu.HUD.SetActive(true);

            Bird.transform.position = Vector3.zero;

            if(!Bird.IsAlive)
                Bird.Revive();

            Bird.gameObject.SetActive(true);

            //Reset the obstacles so the player doesn't go through the same obstacles over again
            obstaclesGenerator.Reset();
        }

        void OnBirdDeath()
        {
            ///Invoke is a Monobehaviour inherited method
            ///It takes two parameters, a string and a float
            ///The string represents a method name
            ///While the float designates a time delay for the specifed method's exeuction
            ///We wait 2 seconds after the bird is dead to invoke the OnEnd method
            ///We do this to give the player time to process the Bird's death
            ///So the player can see the Bird falling down and tumbling away
            Invoke("OnEnd", 2f);
        }

        void OnEnd()
        {
            Menu.HUD.SetActive(false);

            Menu.end.SetActive(true);
        }
        
        /// <summary>
        /// Resets the Game state by returning to the Start Menu and resetting the points
        /// </summary>
        public void Reset()
        {
            Menu.start.SetActive(true);
            Menu.HUD.SetActive(false);
            Menu.end.SetActive(false);

            points = 0;
        }
    }
}
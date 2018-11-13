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
	public class Bird : MonoBehaviour
	{
        //Rigidbody is responsible for all physics operations
        new Rigidbody2D rigidbody;

        //Animator is resposible for all animations
        Animator animator;

        //Audio source is responsible for audio
        AudioSource audioSource;

        //Flag bolean to designate if the bird is alive
        bool isAlive = true;
        public bool IsAlive { get { return isAlive; } }

        /// <summary>
        /// Awake is called when the component is first initialized
        /// Used to get all external dependancies (components)
        /// </summary>
        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();

            animator = GetComponent<Animator>();

            audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Update is called everyframe of the game
        /// Ie: if your game is running 60 Frames Per Second (FPS), the Update method will be called 60 times a second
        /// </summary>
        void Update()
        {
            ProcessMovement();

            ProcessRotation();
        }

        //Horizontal velocity (X axis velocity)
        public float moveVelocity = 4f;

        //Vertical velocity (Y axis velocity) when ever the player flaps
        public float flapVelcoity = 9f;
        public AudioClip flapSound;

        void ProcessMovement()
        {
            if (!isAlive) return;

            ///Retrieve the rigidbody's velocity because we can't modify its internals directly
            ///So "rigidbody.velocity.x = 20" isn't allowed because of how C# works
            var velocity = rigidbody.velocity;

            velocity.x = moveVelocity;

            if (CheckInput())
            {
                velocity.y = flapVelcoity;
                audioSource.PlayOneShot(flapSound);
            }

            //Apply the velocity back to the rigidbody
            rigidbody.velocity = velocity;

            ///Only have the animator playing if we are going up (velocity.y is bigger than zero)
            ///Makes sense, since the bird would only flap its wings to go up
            if (rigidbody.velocity.y > 0)
                animator.speed = 1f;
            else
                animator.speed = 0f;
        }

        /// <summary>
        /// Check if the player provided any input (key push, screen touch, ... )
        /// </summary>
        /// <returns></returns>
        bool CheckInput()
        {
            return Input.anyKeyDown;
        }

        [Space]
        //Multiplier for the rotation, can be used to make the bird rotate either less or more
        public float rotationMultiplier = 4f;

        //Represents the maximum angle that the bird will have
        public const float AngleLimit = 60f;

        void ProcessRotation()
        {
            if (!isAlive) return;

            ///Retrieve the transform's euler angles because we can't modify its internals directly
            ///So "transform.eulerAngles.x = 20" isn't allowed because of how C# works
            var angles = transform.eulerAngles;

            //Set the z angle (2D rotation) according to the rigidbody's velocity and multiply it by the rotationMultiplier
            angles.z = rigidbody.velocity.y * rotationMultiplier;

            //Limit the z angle (2D rotation) to the AngleLimit so the bird won't rotate too much (flip around)
            angles.z = Mathf.Clamp(angles.z, -AngleLimit, AngleLimit);

            //Apply the eueler angles back to the transform
            transform.eulerAngles = angles;
        }

        /// <summary>
        /// Unity callback called when ever a 2D collision occurs
        /// The collision parameter provides information about the collision that happened
        /// </summary>
        /// <param name="collision"></param>
        void OnCollisionEnter2D(Collision2D collision)
        {
            //Check if we are still alive, no need to kill the bird if it's already did
            if(isAlive)
                Die();
        }

        [Space]
        public AudioClip hitSound;
        public AudioClip deathSound;

        //An event that is raised whenever the bird dies
        public event Action OnDeath;

        void Die()
        {
            if (!isAlive) return;

            isAlive = false;

            animator.speed = 0f;

            ///Remove any constraints on the rigidbody's movement and rotation
            ///This way the bird can tumble into the ground
            rigidbody.constraints = RigidbodyConstraints2D.None;

            audioSource.PlayOneShot(hitSound);
            audioSource.PlayOneShot(deathSound);

            if (OnDeath != null)
                OnDeath();
        }

        /// <summary>
        /// Revive the bird from death so it can fly again
        /// Hallelujah !!!
        /// </summary>
        public void Revive()
        {
            isAlive = true;

            animator.speed = 1f;

            //Freeze the rigidbody's rotation since we will take control over it from here
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

            transform.eulerAngles = Vector3.zero;

            //reset the velocity and angular velicty so they won't affect the bird's new state
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0f;
        }
	}
}
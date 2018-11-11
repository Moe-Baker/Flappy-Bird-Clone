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
	public class Bird : MonoBehaviour
	{
        new Rigidbody2D rigidbody;
        Animator animator;
        AudioSource audioSource;

        bool isAlive = true;
        public bool IsAlive { get { return isAlive; } }

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();

            animator = GetComponent<Animator>();

            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            ProcessMovement();

            ProcessRotation();
        }

        public float jumpVelocity = 4f;
        public AudioClip jumpSound;
        public float moveVelocity = 4f;
        void ProcessMovement()
        {
            if (!isAlive) return;

            var velocity = rigidbody.velocity;

            velocity.x = moveVelocity;

            if (CheckInput())
            {
                velocity.y = jumpVelocity;
                audioSource.PlayOneShot(jumpSound);
            }

            rigidbody.velocity = velocity;
        }
        bool CheckInput()
        {
            return Input.GetMouseButtonDown(0);
        }

        public float rotationScale = 4f;
        void ProcessRotation()
        {
            if (!isAlive) return;

            var angles = transform.eulerAngles;

            angles.z = rigidbody.velocity.y * rotationScale;

            transform.eulerAngles = angles;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if(isAlive)
                Die();
        }

        public AudioClip hitSound;
        public AudioClip deathSound;
        public event Action OnDeath;
        void Die()
        {
            if (!isAlive) return;

            isAlive = false;

            animator.speed = 0f;
            rigidbody.constraints = RigidbodyConstraints2D.None;

            audioSource.PlayOneShot(hitSound);
            audioSource.PlayOneShot(deathSound);

            if (OnDeath != null)
                OnDeath();
        }

        public void Revive()
        {
            isAlive = true;

            animator.speed = 1f;
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

            transform.eulerAngles = Vector3.zero;
            rigidbody.velocity = Vector3.zero;
        }
	}
}
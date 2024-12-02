﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;
        public InputAction MoveAction;
        public InputAction InteractAction;
        public GameObject projectilePrefab;
        Vector2 direction = new Vector2(0,0);
        
        Rigidbody2D rigidbody2d;

        void FindObject()
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f,  direction, 0.5f, LayerMask.GetMask("Layer 4"));
            
            if ( hit.collider != null);
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject+direction);
                
            }
            
          
        }


        private void Start()
        {
            animator = GetComponent<Animator>();
            InteractAction.Enable();
            MoveAction.Enable();
            rigidbody2d = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                dir.x = -1;
                direction=new Vector2(-1,0);
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                dir.x = 1;
                direction=new Vector2(1,0);
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                dir.y = 1;
                direction=new Vector2(0,1);
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                dir.y = -1;
                direction=new Vector2(0,-1);
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().linearVelocity = speed * dir;
            
            if (Input.GetKeyDown(KeyCode.E))
            {
              FindObject();
            }
        }
    }
}
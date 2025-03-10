using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public Transform cameraTransform;
    public ParticleSystem dustEffect; 

    public float walkSpeed = 2f;
    public float runSpeed = 6f;
    public float gravity = 9.81f;
    public float rotationSpeed = 10f;

    private Vector3 velocity;

    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();

        if (animator == null)
            animator = GetComponent<Animator>();

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        if (dustEffect != null)
            dustEffect.Stop(); 
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = (moveX != 0 || moveZ != 0) ? (isRunning ? runSpeed : walkSpeed) : 0f;

        if (animator != null)
        {
            if (currentSpeed > 0.1f)
            {
                animator.SetFloat("Speed", currentSpeed, 0.1f, Time.deltaTime);
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetFloat("Speed", 0);
                animator.SetBool("isWalking", false);
            }
        }

        Vector3 moveDirection = cameraTransform.forward * moveZ + cameraTransform.right * moveX;
        moveDirection.y = 0;
        moveDirection.Normalize();

        if (moveDirection.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        if (!controller.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -5f;
        }

        controller.Move(velocity * Time.deltaTime);

       
        if (dustEffect != null)
        {
            if (currentSpeed > 0.1f)
            {
                if (!dustEffect.isPlaying)
                    dustEffect.Play();
            }
            else
            {
                if (dustEffect.isPlaying)
                    dustEffect.Stop();
            }
        }
    }
}

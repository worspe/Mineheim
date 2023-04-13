using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private PlayerAnim playerAnim;

    Vector3 velocity;
    bool isGrounded;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public AudioClip walkingSound;

    private AudioSource playerAudio;
    private CharacterController characterController;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GameObject.Find("Player").GetComponent<PlayerAnim>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (direction.magnitude >= 0.1f && !playerAnim.isMining)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);



            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (characterController.velocity.magnitude > 0 && !playerAudio.isPlaying)
        {
            playerAudio.clip = walkingSound;
            playerAudio.Play();
        }
        else if (characterController.velocity.magnitude == 0 && playerAudio.isPlaying)
        {
            playerAudio.Stop();
        }
    }
}


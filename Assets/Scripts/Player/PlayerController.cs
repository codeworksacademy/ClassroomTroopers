using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 MoveInput;
    private Rigidbody2D rb;
    private Animator animator;
    private Player player;
    private AudioSource audioSource;

    public bool UseFootstepSounds = true;
    public List<AudioClip> FootstepSounds;





    void Start()
    {
        // NOTE get the component from the game object that this script is attached to
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }



    // Update is called once per frame
    void Update()
    {
        MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveInput = MoveInput.normalized;


        if (Input.GetButtonDown("pause"))
        {
            Debug.Log("pausing the game? " + Time.timeScale);
            Time.timeScale = Time.timeScale != 0 ? 0 : 1;
        }


        // Things you want to see happen visually each frame

        // Flip the character based on direction
        if (MoveInput.x > .1f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (MoveInput.x < -.1f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (Math.Abs(MoveInput.magnitude) > .1f)
        {
            animator.SetBool("isRunning", true);
            if (!audioSource.isPlaying)
            {
                audioSource.clip = FootstepSounds[UnityEngine.Random.Range(0, FootstepSounds.Count)];
                audioSource.Play();
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            audioSource.Stop();
        }


    }


    // NOTE The physics update
    void FixedUpdate()
    {
        rb.linearVelocity = MoveInput * player.MoveSpeed;
    }

}

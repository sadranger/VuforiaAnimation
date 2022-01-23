using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMovement : MonoBehaviour
{

    Animator animator;
    int isWalkingHash, isRunningHash, isDancingHash, isJumpingHash, isSlidingHash;
    AudioSource danceSound;
    

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        danceSound = GetComponent<AudioSource>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isDancingHash = Animator.StringToHash("isDancing");
        isJumpingHash = Animator.StringToHash("isJumping");
        isSlidingHash = Animator.StringToHash("isSliding");
        
    }

    // Update is called once per frame
    void Update()
    {

        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        bool isDancing = animator.GetBool("isDancing");
        bool isJumping = animator.GetBool("isJumping");
        bool isSliding = animator.GetBool("isSliding");

        bool walkPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool dancePressed = Input.GetKey("x");
        bool jumpPressed = Input.GetKey("space");
        bool slidePressed = Input.GetKey("left ctrl");

        if (!isWalking && walkPressed)
        {

            animator.SetBool(isWalkingHash, true);

        }

        if (isWalking && !walkPressed)
        {

            animator.SetBool(isWalkingHash, false);
        }

        if (isWalking && (!isRunning && runPressed))
        {

            animator.SetBool(isRunningHash, true);
            print("inside running true");

        }

        if (isWalking && (isRunning && !runPressed))
        {

            print("inside running false");
            animator.SetBool(isRunningHash, false);

        }

        if (!isWalking)
        {
            animator.SetBool(isRunningHash, false);
        }

        if(!isDancing && dancePressed)
        {
            PlaySound();
            animator.SetBool(isDancingHash, true);

        }

        if (isDancing && !dancePressed)
        {

            animator.SetBool(isDancingHash, false);

        }

        if (isWalking && (!isJumping && jumpPressed))
        {

            animator.SetBool(isJumpingHash, true);
            print("inside jumping true");

        }

        if (isWalking && (isJumping && !jumpPressed))
        {

            print("inside jumping false");
            animator.SetBool(isJumpingHash, false);

        }

        if (isWalking && (!isSliding && slidePressed))
        {

            animator.SetBool(isSlidingHash, true);
            print("inside sliding true");

        }

        if (isWalking && (isSliding && !slidePressed))
        {

            print("inside sliding false");
            animator.SetBool(isSlidingHash, false);

        }


        /* else
         {
             print("inside running false");
             animator.SetBool(isRunningHash, false);
         }*/
    }

    private void PlaySound()
    {
        danceSound.Play();
    }

}

    

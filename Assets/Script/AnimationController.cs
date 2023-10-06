using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (speed.speedNow > 0)
        {

            animator.SetBool("isRunning", true);

            

        }

        else
        {

            animator.SetBool("isRunning", false);
        }
    }
}

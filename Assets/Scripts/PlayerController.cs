using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Joystick joystick;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementLogic();
    }
    void MovementLogic()
    {
        Vector3 movement = new Vector3(joystick.Vertical * 100f, 0, joystick.Horizontal * -100f);
        controller.Move(movement * Time.deltaTime);
       
        if(joystick.Vertical > 0.01 || joystick.Horizontal > 0.01 || joystick.Horizontal < -0.01 || joystick.Vertical < -0.01)
            
        {
            gameObject.transform.rotation = Quaternion.LookRotation(movement);
            animator.Play("Running");
        }    
        else
        {
            animator.Play("Idle");
        }
    }
}

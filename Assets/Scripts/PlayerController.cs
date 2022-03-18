using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    Transform backpackTransform;
    CharacterController controller;
    Joystick joystick;
    Animator animator;
    UIScript uiscript;
    Animator backpack_animator;
    // Start is called before the first frame update
    void Start()
    {
        backpackTransform = GameObject.Find("BackPack").transform;
        backpack_animator = GameObject.Find("BackPack").GetComponent<Animator>();
        uiscript = GameObject.Find("PlayerCanvas").GetComponent<UIScript>();
        animator = gameObject.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        joystick = GameObject.Find("Floating Joystick").GetComponent<Joystick>();
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Punch");

        }
        if (joystick.Vertical != 0 && joystick.Horizontal != 0 || joystick.Vertical != 0 || joystick.Horizontal != 0)
            
        {
            gameObject.transform.rotation = Quaternion.LookRotation(movement);
            animator.ResetTrigger("Idle");
            backpack_animator.SetTrigger("BackAnim");
            animator.SetTrigger("Running");
            
        }
        else
        {
            backpack_animator.ResetTrigger("BackAnim");
            backpack_animator.SetTrigger("BackIdle");
            animator.ResetTrigger("Running");
            animator.SetTrigger("Idle");
            
        }
       

        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WheatBlock")
        {
            PickUpLogic(other.gameObject);

        }
    }
    void PickUpLogic(GameObject block)
    {
        uiscript.AddBlock(block.GetComponent<WheatBlock>().wheatBlockSO.Count);
        BlockToBack();
        StartCoroutine(DestroyWithDelay(block, 0.5f));
    }
    void BlockToBack()
    {

        backpackTransform.DOScale(new Vector3(2, 2, 2), 2);
    }
    IEnumerator DestroyWithDelay(GameObject go, float seconds)
    {
        GameObject thisGo = go;
        yield return new WaitForSeconds(seconds);
        Destroy(thisGo);
        
    }
    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(1f);
        animator.ResetTrigger("Punch");
    }    
}

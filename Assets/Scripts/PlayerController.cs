using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    Transform ambarTransform;
    Transform backpackTransform;
    CharacterController controller;
    Joystick joystick;
    Animator animator;
    UIScript uiscript;
    Animator backpack_animator;
    [SerializeField]
    GameObject wheatBlock;
    private bool droppingBlock;
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
       


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "WheatBlock")
        {
            GameObject thatBlock = other.gameObject;
            if (thatBlock.GetComponent<WheatBlock>().pickable == true)
            {
                if (uiscript.invFull != true && thatBlock.GetComponent<WheatBlock>().toDrop != true)
                {
                    PickUpLogic(thatBlock);
                    thatBlock.GetComponent<WheatBlock>().toPickUp = true;

                }
            }


        }
        if (other.gameObject.tag == "Ambar" && droppingBlock != true)
        {
            DropBlockToAmbar();
        }
        
    }
    void PickUpLogic(GameObject block)
    {
        block.GetComponent<WheatBlock>().pickable = false;
        uiscript.AddBlock(block.GetComponent<WheatBlock>().wheatBlockSO.Count);
        
        StartCoroutine(DestroyWithDelay(block, 0.5f));
    }
    
    void DropBlockToAmbar()
    {
        if (uiscript.BlocksCount != 0)
        {
            
            GameObject newBlock = Instantiate(wheatBlock, transform.position, Quaternion.identity);
            newBlock.GetComponent<WheatBlock>().toDrop = true;
            StartCoroutine(ToDropWithDelay(0.1f));
            StartCoroutine(DestroyWithDelay(newBlock, 0.5f));
            uiscript.AddBlock(-1);
            uiscript.AddBlockToAmbar();
        }
        else
        {
            print("Here is no blocks");
        }
    }
    IEnumerator ToDropWithDelay(float delay)
    {
        droppingBlock = true;
        yield return new WaitForSeconds(delay);
        droppingBlock = false;
        
         
        
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

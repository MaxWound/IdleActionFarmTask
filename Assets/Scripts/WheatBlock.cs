using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WheatBlock : MonoBehaviour
{
    UIScript uiscript;
     float duration = 0.01f;
    public Transform BackTransform;
    public WheatBlockSO wheatBlockSO;
    private bool toPickUp = false;
    private void Start()
    {
        uiscript = GameObject.Find("PlayerCanvas").GetComponent<UIScript>();
        BackTransform = GameObject.Find("BackPack").GetComponent<Transform>();
    }
    
    private void Update()
    {
        if (toPickUp)
        {
            if (uiscript.invFull != true)
            {
                transform.position = Vector3.Lerp(transform.position, BackTransform.position, duration);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "BlockCollector")
        {
            toPickUp = true;
        }
    }
    //transform.DOMove(BackTransform.position, duration);
}

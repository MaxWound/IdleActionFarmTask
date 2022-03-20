using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WheatBlock : MonoBehaviour
{
    UIScript uiscript;
    float duration = 0.1f;
    Transform BackTransform;
    Transform AmbarTransform;
    public WheatBlockSO wheatBlockSO;
    public bool toPickUp = false;
    public bool toDrop = false;
    public bool pickable = true;
    private void Start()
    {
        uiscript = GameObject.Find("PlayerCanvas").GetComponent<UIScript>();
        BackTransform = GameObject.Find("BackPack").GetComponent<Transform>();
        AmbarTransform = GameObject.Find("Ambar").GetComponent<Transform>();
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
        if (toDrop)
            
        {
            transform.position = Vector3.Lerp(transform.position, AmbarTransform.position, duration);
        }
    }

    //transform.DOMove(BackTransform.position, duration);
}

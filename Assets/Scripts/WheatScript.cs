using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WheatScript : MonoBehaviour
{
    public Animation BrokeAnim;
    public GameObject testGameObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            BreakWheat(testGameObject);
        }

    }
    private void Start()
    {
        
    }
    public void BreakWheat(GameObject wheat)
    {

        Transform WheatTransform = wheat.gameObject.transform;
        Vector3 WheatPos = WheatTransform.position;
        Quaternion WheatRot = WheatTransform.rotation;
        GameObject brokenWheat = wheat.GetComponent<Wheat>().brokenWheat;
        
        Destroy(wheat);
        GameObject newBrokenWheat = Instantiate(brokenWheat, WheatPos,Quaternion.identity);
        newBrokenWheat.GetComponent<Animator>().Play("WheatBreak");
        
    }
}

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
       

    }
    private void Start()
    {
        
    }
    IEnumerator DestroyWithDelay(GameObject go)
    {
        GameObject thisGo = go;
        yield return new WaitForSeconds(4);
        Destroy(thisGo);
    }
    public void LifeOfBrokenWheat(GameObject brokenGO)
    {
        brokenGO.transform.GetChild(1).GetComponent<Animator>().Play("WheatBreak");
        StartCoroutine(DestroyWithDelay(brokenGO));
    }
    public void BreakWheat(GameObject wheat)
    {

        Transform WheatTransform = wheat.gameObject.transform;
        WheatTransform.transform.GetComponentInParent<WheatSpawner>().wheatSpawned = false;

        Vector3 WheatPos = WheatTransform.position;
        Quaternion WheatRot = WheatTransform.rotation;
        GameObject brokenWheat = wheat.GetComponent<Wheat>().brokenWheat;
        GameObject wheatBlock = wheat.GetComponent<Wheat>().wheatBlock;
        Vector3 spawnBlockPos = wheat.GetComponent<Wheat>().blockSpawnerPos;
        Destroy(wheat);
        GameObject newBrokenWheat = Instantiate(brokenWheat, WheatPos, Quaternion.Euler(0, Random.Range(0,360) , 0));
        GameObject newBlock = Instantiate(wheatBlock, spawnBlockPos   , Quaternion.Euler(0, Random.Range(0, 360), 0));
        newBlock.transform.parent = null;
       
        LifeOfBrokenWheat(newBrokenWheat);
        
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wheat : MonoBehaviour
// Start is called before the first frame update
{
    WheatScript wheatScript;
    public GameObject Serp;
    public int CountOfWheat;
    public GameObject brokenWheat;
    public GameObject wheatBlock;
    public Vector3 blockSpawnerPos;
    private void Start()
    {
        blockSpawnerPos = transform.GetChild(0).transform.position;
        Serp = GameObject.Find("Serp");
        wheatScript = GameObject.Find("Ambar").GetComponent<WheatScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Serp")
        {
            wheatScript.BreakWheat(gameObject);
        }
    }



}

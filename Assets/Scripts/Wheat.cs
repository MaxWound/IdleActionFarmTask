using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wheat : MonoBehaviour
// Start is called before the first frame update
{
    [SerializeField]
    GameObject BlockSpawner;
    WheatScript wheatScript;
    public GameObject Serp;
    public int CountOfWheat;
    public GameObject brokenWheat;
    public GameObject wheatBlock;
    public Vector3 blockSpawnerPos;
    private void Start()
    {
        blockSpawnerPos = BlockSpawner.transform.position;
        Serp = GameObject.Find("Serp");
        wheatScript = GameObject.Find("Ambar").GetComponent<WheatScript>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Serp")
        {
            wheatScript.BreakWheat(gameObject);
        }
    }
    
    



}

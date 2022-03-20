using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject wheatSpawnerObj;
    [SerializeField]
    GameObject wheatToSpawn;
    [SerializeField]
    float delayTime;
    public bool wheatSpawned;

    float timerTime;
    private void Start()
    {
        wheatSpawned = true;
        var newWheat = Instantiate(wheatToSpawn, wheatSpawnerObj.transform.position, Quaternion.Euler(-90, 0, Random.Range(0, 360)));
        newWheat.transform.parent = gameObject.transform;

        timerTime = 0;
    }
    private void Update()
    {
        if (timerTime >= delayTime && wheatSpawned != true)
        {
            wheatSpawned = true;
            var newWheat = Instantiate(wheatToSpawn, wheatSpawnerObj.transform.position, Quaternion.Euler(-90, 0, Random.Range(0, 360)));
            newWheat.transform.parent = gameObject.transform;
            
            timerTime = 0;
            
        }
        else if (wheatSpawned == true)
        {
            timerTime = 0;
        }
        else
        {
            timerTime += Time.deltaTime;
        }
    }
}

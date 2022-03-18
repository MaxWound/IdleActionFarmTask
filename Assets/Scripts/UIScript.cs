using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public bool invFull;
    TMP_Text CounterText;
    int BlocksCount = 0;
    private void Start()
    {
        invFull = false;

        CounterText = GameObject.Find("BlocksCounter").GetComponent<TMP_Text>();
    }
    public void AddBlock(int count)
    {

        if (BlocksCount + count <= 40)
        {
            BlocksCount += count;
            CounterText.text = ($"{BlocksCount + count} / 40");
        }
        else
        {
            invFull = true;
        }
    }
}

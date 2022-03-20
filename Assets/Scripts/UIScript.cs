using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    Animator coinAnimator;
    [SerializeField]
    int BlockCost = 15;
    [SerializeField]
    float ShakeStrength;
    [SerializeField]
    float coinspeed;
    [SerializeField]
    GameObject Coin;
    public bool invFull;
    Transform WheatIconTransform;
    Transform MoneyIconTranform;
    TMP_Text CounterText;
    TMP_Text MoneyText;
    public int BlocksCount = 0;
    int MoneyCount = 0;
    int BlockInAmbar = 0;
    bool blockSelling = false;
    private void Start()
    {
        coinAnimator = GameObject.Find("MoneyIcon").GetComponent<Animator>();
        MoneyIconTranform = GameObject.Find("MoneyIcon").GetComponent<Transform>();
        WheatIconTransform = GameObject.Find("WheatIcon").GetComponent<Transform>();
        invFull = false;
        MoneyText = GameObject.Find("MoneyCounter").GetComponent<TMP_Text>();
        CounterText = GameObject.Find("BlocksCounter").GetComponent<TMP_Text>();
        AddMoney(0);
        AddBlock(0);
    }
    public void AddBlock(int count)
    {

        if (BlocksCount + count <= 40)
        {
            invFull = false;
            BlocksCount += count;
            CounterText.text = ($"{BlocksCount} / 40");
        }
        else
        {
            invFull = true;
        }
    }
    public void AddMoney(int count)
    {
        MoneyCount += count;
        MoneyText.text = ($"{MoneyCount}");
    }
    public void AddBlockToAmbar()
    {
        BlockInAmbar++;
    }
    public void RemoveBlockFromAmbar()
    {
        BlockInAmbar--;
    }    
    //FOR TEST
    private void Update()
    {
        if (BlockInAmbar != 0 && blockSelling == false)
        {
            SellBlock();
        }
    }
    IEnumerator SellWithDelay()
    {
        blockSelling = true;
        yield return new WaitForSeconds(0.5f);
            blockSelling = false;
        
    }
    //FOR TEST
    public void SellBlock()
    {
        GameObject newCoin = Instantiate(Coin, WheatIconTransform.position, Quaternion.identity);
        newCoin.transform.parent = gameObject.transform;
        newCoin.transform.DOMove(MoneyIconTranform.position, coinspeed);
        RemoveBlockFromAmbar();
        StartCoroutine(DestroyWithDelay(newCoin, 0.5f));
    }
    void ShakeMoney()
    {
        coinAnimator.ResetTrigger("Anim");
        coinAnimator.SetTrigger("Anim");
    }
    
    IEnumerator DestroyWithDelay(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        ShakeMoney();
        Destroy(go);
        AddMoney(BlockCost);
    }
}

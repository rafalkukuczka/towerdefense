using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuMenuGridController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetActive(1, GameData.IsRocketVisible());  

        SetActive(2, GameData.IsBombVisible());

        SetActive(3, GameData.IsHealthVisible());
    }

    private void SetActive(int idx, bool isActive)
    {
        var levelSelector = this.transform.GetChild(idx-1).GetComponent<BuyItemController>();
        levelSelector.SetActive(isActive);
    }

    public void OnClicked(string itemName)
    {
        Debug.Log("ShopMenuMenuGridController.OnClicked..." + itemName +"!!!");
        //StartCoroutine(OnClick());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

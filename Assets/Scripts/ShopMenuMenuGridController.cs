using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuMenuGridController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetActive(1, true);  //RK TODO Make BuyMenuItems function

        SetActive(2, GameData.IsSecondScreenVisible());

        SetActive(3, GameData.IsThirdScreenVisible());

        

    }

    private void SetActive(int idx, bool isActive)
    {
        var levelSelector = this.transform.GetChild(idx-1).GetComponent<BuyItemController>();
        levelSelector.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

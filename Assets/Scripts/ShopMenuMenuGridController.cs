using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenuMenuGridController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Activate buy items
        SetActive(1, GameData.IsRocketBuyItemVisible());  

        SetActive(2, GameData.IsBombBuyItemVisible());

        SetActive(3, GameData.IsForceBuytemVisible());

        SetActive(4, GameData.IsSpeedBuytemVisible());

    }

    private void SetActive(int idx, bool isActive)
    {
        var levelSelector = this.transform.GetChild(idx-1).GetComponent<BuyItemController>();
        levelSelector.SetActive(isActive);
    }

    public void OnClicked(string itemName)
    {
        Debug.Log("ShopMenuMenuGridController.OnClicked..." + itemName +"!!!");
        GameData.WasShoped=true;

        if (itemName == "Rocket")
        {
            GameData.Score -= 400;
            GameData.CurrentNumberOfRockets += GameData.Const.RocketsInCrate;

        }
        else if (itemName == "Bomb")
        {
            GameData.Score -= 500;
            GameData.BombCount += 1;

        }
        else if (itemName == "Force")
        {
            GameData.Score -= 1000;
            GameData.ExtraForceTimeout += GameData.Const.ExtraForceTimeout;
        }
        else if (itemName == "Speed")
        {
            GameData.Score -= 2000;
            GameData.ExtraSpeedTimeout += GameData.Const.ExtraSpeedTimeout; 
        }
        
        else
        {
            throw new ArgumentException();
        }

        //RK TODO Remove
        //SceneManager.LoadScene("MainMenu");
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
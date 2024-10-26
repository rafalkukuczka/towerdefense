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
        SetActive(1, GameData.IsRocketBuyItemVisible());  

        SetActive(2, GameData.IsBombBuyItemVisible());

        SetActive(3, GameData.IsHealthBuyItemVisible());

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
        else if (itemName == "Health")
        {
            GameData.Score -= 1000;
            //GameData.he += 1; //RK Todo implement Health
        }
        else
        {
            throw new ArgumentException();
        }

        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

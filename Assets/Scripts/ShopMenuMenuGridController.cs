using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ShopMenuMenuGridController : MonoBehaviour
{
    BuyItemController _rocketsBuyItemController;
    BuyItemController _bombsBuyItemController;
    BuyItemController _forceBuyItemController;
    BuyItemController _speedBuyItemController;

    BombHUDController _bombHUDController;
    RocketHUDController _rocketHUDController;
    ForceHUDController _forceHUDController;
    SpeedHUDController _speedHUDController;
    PointsLeftTextController _pointsLeftTextController;

    int _initialScore;
    // Start is called before the first frame update
    void Start()
    {
        _rocketsBuyItemController = gameObject.transform.GetChild(0).GetComponent<BuyItemController>();
        _bombsBuyItemController = gameObject.transform.GetChild(1).GetComponent<BuyItemController>();
        _forceBuyItemController = gameObject.transform.GetChild(2).GetComponent<BuyItemController>();
        _speedBuyItemController = gameObject.transform.GetChild(3).GetComponent<BuyItemController>();

        _pointsLeftTextController = GameObject.Find("ui_PointsLeftText").GetComponent<PointsLeftTextController>();
        _bombHUDController = GameObject.Find("ui_bombHUD").GetComponent<BombHUDController>();
        _rocketHUDController = GameObject.Find("ui_rocketHUD").GetComponent<RocketHUDController>();
        _forceHUDController = GameObject.Find("ui_forceHUD").GetComponent<ForceHUDController>();
        _speedHUDController = GameObject.Find("ui_speedHUD").GetComponent<SpeedHUDController>();

        _initialScore = GameData.Score;

    }

    private void SetActive(int idx, bool isActive)
    {
        var levelSelector = this.transform.GetChild(idx-1).GetComponent<BuyItemController>();
        levelSelector.SetActive(isActive);
    }

    public void OnClicked(string itemName)
    {
        //Debug.Log("ShopMenuMenuGridController.OnClicked..." + itemName +"!!!");
        GameData.WasShoped=true;

        if (itemName == "Rocket")
        {
            GameData.Score -= GameData.Const.RocketPrice;
            GameData.CurrentNumberOfRockets += GameData.Const.RocketsInCrate;

        }
        else if (itemName == "Bomb")
        {
            GameData.Score -= GameData.Const.BombsPrice;
            GameData.BombCount += 1;

        }
        else if (itemName == "Force")
        {
            GameData.Score -= GameData.Const.ForcePrice;
            GameData.ExtraForceTimeout += GameData.Const.ForceTimeout;
        }
        else if (itemName == "Speed")
        {
            GameData.Score -= GameData.Const.SpeedPrice;
            GameData.ExtraSpeedTimeout += GameData.Const.SpeedTimeout; 
        }
        
        else
        {
            throw new ArgumentException();
        }

    }

    public void OnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnReset()
    {
        Debug.Log("ShopMenuMenuGridController.OnReset");
        GameData.Init(true);
        GameData.Score = _initialScore;
    }

    // Update is called once per frame
    void Update()
    {
        //Activate buy items
        SetActive(1, GameData.IsRocketBuyItemVisible());

        SetActive(2, GameData.IsBombBuyItemVisible());

        SetActive(3, GameData.IsForceBuytemVisible());

        SetActive(4, GameData.IsSpeedBuytemVisible());

        _rocketsBuyItemController.ItemPrice = GameData.Const.RocketPrice; 
        _bombsBuyItemController.ItemPrice = GameData.Const.BombsPrice; 
        _forceBuyItemController.ItemPrice = GameData.Const.ForcePrice; 
        _speedBuyItemController.ItemPrice = GameData.Const.SpeedPrice;

        _bombHUDController.Text = GameData.BombCount.ToString();
        _bombHUDController.Visible = GameData.BombCount > 0;

        _rocketHUDController.Text = GameData.CurrentNumberOfRockets.ToString();
        _rocketHUDController.Visible = GameData.CurrentNumberOfRockets > 0;

        _forceHUDController.Text = GameData.ExtraForceTimeout.ToString();
        _forceHUDController.Visible = GameData.ExtraForceTimeout > 0;

        _speedHUDController.Text = GameData.ExtraSpeedTimeout.ToString();
        _speedHUDController.Visible = GameData.ExtraSpeedTimeout > 0;

        _pointsLeftTextController.Text = GameData.Score.ToString();

    }

}

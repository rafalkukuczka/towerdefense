using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

[Serializable] public class StringEvent : UnityEvent<string> {
    public string NewState;
}

[ExecuteAlways]
public class BuyItemController : MonoBehaviour
{
    [SerializeField] public Sprite ButtonSprite;

    [SerializeField] public string ItemName;
    [SerializeField] public int ItemPrice;
    [SerializeField] public Color disabledColor = Color.gray;
    [SerializeField] public StringEvent OnClicked;

    Button _button;
    UnityEngine.UI.Image _image;
    TextMeshProUGUI _textBox;
    // Start is called before the first frame update
    void Awake()
    {
        _image = this.gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();

        _textBox = this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        _button = this.gameObject.transform.GetComponent<Button>();

        _textBox.text = ItemPrice.ToString();

        _image.sprite = ButtonSprite;
    }

    private void Update()
    {
        _textBox.text = ItemPrice.ToString();
    }

    private void OnValidate()
    {
        UnityEngine.UI.Image image = this.gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();

        image.sprite = ButtonSprite;

        TextMeshProUGUI textBox = this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        textBox.text = ItemPrice.ToString();


    }

    // Update is called once per frame

    public void OnSelect()
    {
        //RK TODO Remove 
        //UnityEngine.Debug.Log("BuyItemController.OnSelect..." + ItemName);

        StartCoroutine(FireOnClicked());
    }

    IEnumerator FireOnClicked()
    {
        //RK TODO Remove
        //UnityEngine.Debug.Log("BuyItemController.FireOnClicked..." + ItemName + "!");

        if (OnClicked == null)
            yield break;

        OnClicked.NewState = ItemName;

        OnClicked.Invoke(OnClicked.NewState);

        _image.color = disabledColor;

        yield return new WaitForSeconds(1);

        _image.color = Color.white;

        yield return new WaitForSeconds(1);

        //SceneManager.LoadScene(ItemName);

        yield return null;
    }

    public void SetActive(bool state)
    {

        if (state)
        {
            _textBox.color = Color.white;
            _image.color = Color.white;
            _button.interactable = true;
        }
        else
        {
            _textBox.color = Color.gray;
            _image.color = Color.grey;
            _button.interactable = false;
        }


    }
}

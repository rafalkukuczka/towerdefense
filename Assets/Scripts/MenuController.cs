using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public int LevelNumber;

    // Start is called before the first frame update
    void Start()
    {
        //RK TODO Remove
        //SetActive("Level1Selector", "Image1", true);

        if (GameData.Score > 1000)
        {
            SetActive(2, true);
        }
        else
        {
            SetActive(2, false);
        }

        if (GameData.Score > 2000)
        {
            SetActive(3, true);
        }
        else
        {
            SetActive(3, false);
        }


        //RK DEBUG SetActive(4, true);
        if (GameData.Score > 3000)
        {
            SetActive(4, true);
        }
        else
        {
            SetActive(4, false);
        }

    }

    // Update is called once per frame

    public void OnSelect()
    {
        if (LevelNumber == 0)
            return;


        StartCoroutine(OnClick());

    }

    IEnumerator OnClick() {

        var i = GameObject.Find("Image" + LevelNumber).GetComponent<Image>();
        i.color = Color.green;

        yield return new WaitForSeconds(1);

        i.color = Color.white;

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level" + LevelNumber.ToString());

        yield return null;
    }

    void SetActive(int levelIdx, bool state)
    {
        var _image = GameObject.Find("Image"+levelIdx).GetComponent<Image>();
        var _button = GameObject.Find("Level"+levelIdx+"Selector").GetComponent<Button>();

        if (state)
        {
            _image.color = Color.white;
            _button.interactable = true;
        }
        else
        {
            _image.color = Color.grey;
            _button.interactable = false;
        }

        
    }
}

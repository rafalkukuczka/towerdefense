using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update

    internal TextMeshProUGUI _textMeshPro;
    void Awake()
    {
        _textMeshPro = gameObject.transform.Find("PointsText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshPro.text = GameOverScreen.Text;
    }

    public void Reset()
    {
        SceneManager.LoadScene("Level");
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
 
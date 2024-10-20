using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
}
 
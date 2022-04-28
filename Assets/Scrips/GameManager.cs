using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    public Text x2Text;
    public int Score = 0;
    void Start()
    {
        x2Text.gameObject.SetActive(false);
    }


    void Update()
    {
        ScoreText.text = "Score:" + Score;
    }
}

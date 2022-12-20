using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAmount : MonoBehaviour
{
    Text score;
    public static int coinAmount=80;

    void Start()
    {
        score=GetComponent<Text>();
    }

    void Update()
    {
        score.text = coinAmount.ToString();
    }
}

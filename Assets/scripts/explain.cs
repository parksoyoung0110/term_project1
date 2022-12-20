using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class explain : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Update()
    {
        text.transform.position=Camera.main.WorldToScreenPoint(transform.parent.position); //슬라이더의 위치를 따라 다니도록 하  
    }
}

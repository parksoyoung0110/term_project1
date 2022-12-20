using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Color low; //피가 낮을 때
    public Color high; //피가 높을 때
    public Vector3 offset; // 체력 바랑 몬스터 사이 거리

    public void SetHealth(float health, float maxHealth)
    {
        if(health<maxHealth)
            slider.gameObject.SetActive(true); //체력이 닳았을 때
        slider.value=health; //value를 health로
        slider.maxValue=maxHealth; //max value를 max health로

        slider.fillRect.GetComponentInChildren<Image>().color= Color.Lerp(low, high, slider.normalizedValue);   //슬라이더 색 채우기    
    }

    void Update()
    {
        slider.transform.position=Camera.main.WorldToScreenPoint(transform.parent.position + offset); //슬라이더의 위치를 따라 다니도록 하기
    }

}

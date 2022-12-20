using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Color low; //피가 낮을 때
    public Color high; //피가 높을 때
    public Vector3 offset; // 체력 바랑 몬스터 사이 거리

    public void SetMana(float Mana, float maxMana)
    {
        if(Mana<maxMana)
            slider.gameObject.SetActive(true); //체력이 닳았을 때
        slider.value=Mana; //value를 health로
        slider.maxValue=maxMana; //max value를 max health로

        slider.fillRect.GetComponentInChildren<Image>().color= Color.Lerp(low, high, slider.normalizedValue);   //슬라이더 색 채우기    
    }
}

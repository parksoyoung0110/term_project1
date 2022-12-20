using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillExplain : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    public GameObject explain;

    public void OnPointerEnter(PointerEventData evenData)
    {
        explain.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        explain.SetActive(false);
    }
}

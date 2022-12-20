using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject chp;
    public float hp;
    public GameObject UIRestartBtn;
    public Button ExitBtn;
    public Button RetryBtn;
    public GameObject healthbar;

    void Start()
    {
        ExitBtn.onClick.AddListener(Exit);
        RetryBtn.onClick.AddListener(Retry);
        hp=chp.GetComponent<PlayerHP>().currentHP;

    }
    void Update()
    {
        hp=chp.GetComponent<PlayerHP>().currentHP;

        if(hp<=0)
        {
            UIRestartBtn.SetActive(true);
        }

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        Time.timeScale=1.00f;
        chp.transform.position = new Vector3(0,0,0);
        chp.GetComponent<PlayerHP>().currentHP=100;
        healthbar.GetComponent<PlayerHPbar>().SetHealth(chp.GetComponent<PlayerHP>().currentHP,chp.GetComponent<PlayerHP>().MaxHP);
        UIRestartBtn.SetActive(false);
    }

}

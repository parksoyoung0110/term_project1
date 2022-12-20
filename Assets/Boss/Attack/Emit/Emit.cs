using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emit : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource ad;
    public AudioClip attack;


    public void shot()
    {
        ad.PlayOneShot(attack);
        //360번 반복
        for (int i = 0; i < 360; i += 20)
        {
            //총알 생성
            GameObject temp = Instantiate(bullet);

            //2초마다 삭제
            Destroy(temp, 10f);

            //총알 생성 위치를 (0,0) 좌표로 한다.
            temp.transform.position = gameObject.transform.position;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

}

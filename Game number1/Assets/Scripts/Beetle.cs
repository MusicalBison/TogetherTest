using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour

{
    public float speed = 4f;// скорость жука
    bool isWait = false;// переменная отвечающая за ожидание
    bool isHiden = false;// переменная отвечающая за скрытие
    public float WaiTtime = 4f; // всремя ожидания
    public Transform point; // вспомогательная позиция куда будет двигаться жук


    void Start()
    {
        //перемещение вспомогательной позиции в положении которое чуть выше чем жук

        point.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }

    
    void Update()
    { 
        if (isWait == false)// если жук то он перемещается в вспомогательную позиу=цию 
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        if (transform.position == point.position)
        {
            if (isHiden)
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                isHiden = false;
            }
            else
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                isHiden = true;
            }

            isWait = true;
            StartCoroutine(Waiting());
        }
    }



    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(WaiTtime);
        isWait = false;
    }

}

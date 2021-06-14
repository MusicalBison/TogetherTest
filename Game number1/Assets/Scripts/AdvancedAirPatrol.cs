using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAirPatrol : MonoBehaviour
{
    public Transform[] points; //массив точек
    public float speed = 2f;//скорасть
    public float waitTime = 2f; // время ожидания у каждой точки
    bool canGo = true;//вспомогательная переменная разрешение на движение
    int i = 1; // вспомогательная целочисленная переменная 
    void Start()
    {
        transform.position = new Vector3(points[0].position.x, points[0].position.y, transform.position.z);
    }


    void Update()
    {
        if (canGo)
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        if (transform.position == points[i].position)
        {
            if (i < points.Length - 1)
                i++; //прибавляем 1 к i (i=i+1;)
            else
                i = 0;
            canGo = false;
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()//Корутина ожидания
    {
        yield return new WaitForSeconds(waitTime);
        canGo = true;

    }
}

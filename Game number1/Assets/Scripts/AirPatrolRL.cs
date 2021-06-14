using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPatrolRL: MonoBehaviour
{
    public Transform point1;//положение 1 точки
    public Transform point2;//положение 2 точки
    public float speed = 2f;//скороооооооотсь
    public float waitTime = 3f; //время ожидания
    bool canGo = true;//возможность двигаться
    void Start()
    {
        transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (canGo)
            transform.position = Vector3.MoveTowards(transform.position, point2.position, speed * Time.deltaTime);
        if (transform.position == point2.position)
        {
            Transform t = point1;
            point1 = point2;
            point2 = t;

            canGo = false;
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()//Корутина ожидания
    {
        yield return new WaitForSeconds(waitTime);
        canGo = true;
        //если пчёлка смотрит влево то поворачиваем вправо
        if (transform.rotation.y == 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        //иначе поварачиваем её влево
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}

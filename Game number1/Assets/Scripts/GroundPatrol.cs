using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    public float speed = 1.5f; //скорость мыши
    public bool moveLeft = true; //Переменная отвечающая за направление движения
    public Transform groundDetect; //наш детектор
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); //  перемещение врага влево
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down,1f);//Получение информации об объекте столкновения с лучом:/
         
    if (groundInfo.collider == false)// проверяем закончилась ли платформа
        {
            if (moveLeft == true)//если двигались влево, то двигаемся направо 
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;
            }
        }   
    }
}
     
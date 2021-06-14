using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour

{
    public GameObject bullet;//Снаряд
    public Transform shoot;//место откуда появляется снаряд
    public float timeShoot = 4f;//период появления
    void Start()
    {
        //присваиваем переменной shoot коорденаты пчеляти по y на 1 меньше 
        shoot.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        StartCoroutine(Shooting()); //сщздаём корутину которая отвечает за создание снарядов
    }

    // Update is called once per frame
    void Update()
    {

    }

    //корутина которая создаёт снаряды
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(timeShoot);
        Instantiate(bullet, shoot.transform.position, transform.rotation); //сoздаём снаряд
        StartCoroutine(Shooting());
    } 


}

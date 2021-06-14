using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    float speed = 3f; // скорость камеры
    public Transform target; // Переменная отвечающая за позицию азыбырдулкулбыка
    // Start is called before the first frame update
    void Start()
    {
        // присваиваем позиции камеры позицию игрока
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.position;
        position.z = transform.position.z;
        //Плавное перемещение камеры
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}

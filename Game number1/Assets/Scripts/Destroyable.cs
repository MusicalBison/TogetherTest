using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 10f, ForceMode2D.Impulse);
            //вызываем метод StartDeath скрипта Enemy который находится у родителья Aim
            gameObject.GetComponentInParent<enemy>().StartDeath();
        }

    }
}

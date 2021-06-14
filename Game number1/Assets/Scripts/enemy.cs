using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    bool isHit = false; //Вспомогательная переменная отвечающая за возможность нанесения урону азыдыкурдылбыка
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isHit)
        {
            collision.gameObject.GetComponent<Player>().RecountHp(-1);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 10f, ForceMode2D.Impulse);
        }

    }
    //Метод который вызывает корутину Death
    public void StartDeath()
    {
        StartCoroutine(Death());
    }
    //корутина отвечающая отвечающая за воспроизведение анимации смерти падения вниз и уничтожения врага

    IEnumerator Death()
    {
       
        isHit = true;
        GetComponent<Animator>().SetBool("Dead", true); //включаем анимацию смерти
        //изменяем тип объекта с кинематического на динамический теперь  на объект действует гравитация
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        //Выключаем коллайдер врага
        GetComponent<Collider2D>().enabled = false;
        transform.GetChild(0).GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(2f); //Ждём 2 секунды
        Destroy(gameObject); //чклое уничтожение врага 

    }

}


   



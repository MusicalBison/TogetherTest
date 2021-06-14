using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 3f; //скорость снаряда
    float TimeToDisabled = 10f; //время через которое скрывается снаряд
    
    void Start()
    {
        StartCoroutine(SetDisable());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }


    
        IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(TimeToDisabled);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(SetDisable());
        gameObject.SetActive(false);
    }
}

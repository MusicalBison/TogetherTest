using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb; // Переменная, отвечающая за физику
    public float health;
    public float speed; //Скорость
    public float jumpHeight; //Прыжок
    public Transform groundCheck; // Позиция Ground check
    bool isGround; // Наличие земли под ногами
    Animator anim; //Переменная,отвечающая за анимации
    int curHp; // Текущее здоровье
    int maxHp = 6; // Максимальное количество жизне
    public Main main;//перменная с помощью которой мы будем перезагружать сцену(типа Main)
    bool isHit = false; // перменная которая равна true когда азыдыкырдилбык краснеет 
    public int score;
    public Text scoreText;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Присваиваем rb Rigidbody2D
        anim = GetComponent<Animator>(); //Присваимаем anim  компонент Animator
        curHp = maxHp; //  В начале максимальное здоровье
    }


    void Update()
    {
        Flip();
        Jump();
        GroundCheck();
        if (Input.GetAxis("Horizontal") == 0 && isGround)
            anim.SetInteger("State", 1); // анимация спокойствия
        else
        {
            Flip();
            if (isGround)
                anim.SetInteger("State", 2);
        }

        if (transform.position.y < -40f)
            RecountHp(-6);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8.5f;
        }
        else
        {
            speed = 5f;
        }
    }
    //Метод, который вызывается определенное кол-во раз в секунду
    void FixedUpdate()
    {
        //Управление нашим героям
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }


        }






    }
    //Метод, отвечающий за поворот нашего героя
    void Flip()
    {
        //Если нажать вправо, то поворот направо
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        //Если нажимаем налево, то идём налево
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        //Прыжок



    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);

        }


    }
    //Метод проверяющий на земле ли аздыбуркулдык
    void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGround = colliders.Length > 1;
        if (!isGround)
            anim.SetInteger("State", 3);

    }

    public void AddCoid(int count)
    {
        score += count;

        scoreText.text = score.ToString();

    }

    // Метод который пересчитывает текущее здоровье
    public void RecountHp(int deltaHp)
    {
        curHp = curHp + deltaHp;
        print(curHp);
        if (deltaHp < 0)
        {
            StopCoroutine(OnHit());
            isHit = true;
            StartCoroutine(OnHit());

        }
        if (curHp <= 0)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false; // Падение игрока
            Invoke("Lose", 1.5f);
        }
    }
    //Метод который вызывает перезагрузку даннной сцены
    void Lose()
    {
        main.GetComponent<Main>().Lose();
    }
    //Корутина плавно изменяющая цвет во время получения урония
    IEnumerator OnHit()
    {
        // покраснение чела и его в исходное состояние
        if (isHit)
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.04f, GetComponent<SpriteRenderer>().color.b - 0.04f);
        else
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.04f, GetComponent<SpriteRenderer>().color.b + 0.04f);

        if (GetComponent<SpriteRenderer>().color.g <= 0) // проверка полного покраснения
            isHit = false;

        if (GetComponent<SpriteRenderer>().color.g == 1) // проверка возврата цвета в исходное состояние
            StopCoroutine(OnHit());

        yield return new WaitForSeconds(0.02f); //ожидание 0.02 секунды
        StartCoroutine(OnHit()); //Вызов текущей корутины

    }
}


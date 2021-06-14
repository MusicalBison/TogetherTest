using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{


    public Image Bar;
    public float fill;

    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        fill -= Time.deltaTime * 0.0f;
        Bar.fillAmount = fill;
    }
}

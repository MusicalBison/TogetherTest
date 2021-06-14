using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    //Метод при котором будет перезагружаться текущая сцена
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

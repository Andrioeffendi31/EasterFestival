using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static string Name;
    public GameObject inputField;
    public void StoreName()
    {
        Name = inputField.GetComponent<Text>().text;
        Debug.Log(Name);
    }
    public void play()
    {
        Player_controller.normalScore = 0;
        Player_controller.superScore = 0;

        SceneManager.LoadScene(Random.Range(1, 4));
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text Name, FinalScore;
    void Start()
    {
        Name.text = "Nice Job, " + GameManager.Name + " !";
        FinalScore.text = (Player_controller.normalScore + (2 * Player_controller.superScore)).ToString();
    }
}

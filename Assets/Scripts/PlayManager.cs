using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public float detik = 59;
    public float menit = 3;

    public Text TimeLimit;
    public Image timesup;
    public GameObject player;
    public GameObject Sounds;

    private bool isPlaying = false;
    float delay = 0f;

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            delay = delay + 1 * Time.deltaTime;
            if (delay >= 7)
            {
                isPlaying = true;
                delay = 0;
            }
        }

        if (isPlaying)
        {
            if(Sounds.gameObject.activeSelf == false)
            {
                Sounds.gameObject.SetActive(true);
            }
            if (!player.gameObject.GetComponent<Player_controller>().enabled)
            {
                player.gameObject.GetComponent<Player_controller>().enabled = true;
            }
            TimeLimit.text = (menit + " : " + (int)detik).ToString();
            detik -= 1 * Time.deltaTime;
            if (detik <= 0)
            {
                if (menit > 0)
                {
                    menit--;
                    detik = 59;
                }
            }

            if (menit <= 0 && detik <= 0)
            {
                TimeLimit.gameObject.SetActive(false);
                timesup.gameObject.SetActive(true);
                player.GetComponent<Animator>().SetBool("isWalking", false);
                player.GetComponent<Animator>().SetBool("isRunning", false);
                player.GetComponent<Animator>().SetBool("isJump", false);
                player.GetComponent<Player_controller>().enabled = !player.GetComponent<Player_controller>().enabled;
                Debug.Log("Time's Up");
                StartCoroutine(ChangeToScene("Finish"));
            }
        }
        
    }

    public IEnumerator ChangeToScene(string sceneToChangeTo)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToChangeTo);
    }
}

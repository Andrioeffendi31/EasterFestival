using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.GetChild(4).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
        } 
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.GetChild(5).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.GetChild(6).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.GetChild(7).gameObject.SetActive(true);
            this.transform.GetChild(3).gameObject.SetActive(false);
        }



        if (Input.GetKeyUp(KeyCode.W))
        {
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            this.transform.GetChild(5).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            this.transform.GetChild(6).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            this.transform.GetChild(7).gameObject.SetActive(false);
            this.transform.GetChild(3).gameObject.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Player_controller : MonoBehaviour
{
    Animator anim;
    private float h;
    private float v;
    float kecepatan = 5f;
    public Joystick joystick;
    public static int normalScore = 0;
    public static int superScore = 0;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    float delay = 0f;
    public bool abisLompat = false;

    public Text normalEggCollected;
    public Text superEggCollected;

    public bool isGrounded;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.4f, 0.0f);
        this.transform.GetChild(4).gameObject.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            Vector3 targetDirection = new Vector3(h, 0f, v);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            this.transform.rotation = targetRotation;

            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) * v * Time.deltaTime * kecepatan;
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up) * h * Time.deltaTime * kecepatan;
            this.GetComponent<Animator>().SetBool("isWalking", true);

            if (h > 0.4 || v > 0.4 || h < -0.4 || v < -0.4)
            {
                this.GetComponent<Animator>().SetBool("isRunning", true);
            }
            else
            {
                this.GetComponent<Animator>().SetBool("isRunning", false);
            }

        }
        else
        {
            this.GetComponent<Animator>().SetBool("isRunning", false);
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }

        jumpState();
    }

    void jumpState()
    {
        if (abisLompat)
        {
            Debug.Log("delay : " + delay);
            delay = delay + 0.9f * Time.deltaTime;
            if (delay >= 1)
            {
                abisLompat = false;
                delay = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                this.GetComponent<Animator>().SetBool("isJump", true);
                abisLompat = true;
                isGrounded = false;

            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void ResetJump()
    {
        this.GetComponent<Animator>().SetBool("isJump", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "egg")
        {
            this.transform.GetChild(4).gameObject.GetComponent<ParticleSystem>().Play();
            GameObject.Find("CoinSFX").gameObject.GetComponent<AudioSource>().Play();
            normalScore++;
            normalEggCollected.text = normalScore.ToString();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "superEgg")
        {
            this.transform.GetChild(4).gameObject.GetComponent<ParticleSystem>().Play();
            GameObject.Find("CoinSFX").gameObject.GetComponent<AudioSource>().Play();
            superScore++;
            superEggCollected.text = superScore.ToString();
            Destroy(other.gameObject);
        }
    }
}

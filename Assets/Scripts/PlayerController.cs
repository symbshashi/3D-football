using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    public float moveSpeed;

    float xInput;
    float yInput;

    Rigidbody rb;

    int CoinsColleted;
    public GameObject WinText;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (transform.position.y <= -5f)
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
       
    }

    private void FixedUpdate()
    {
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
       
    }
    void Jump()
    {
        rb.velocity = Vector3.up * jumpForce;
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            CoinsColleted++;
            other.gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
        }
        if (CoinsColleted >= 7)
        {
            WinText.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}

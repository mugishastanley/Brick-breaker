using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() {
        if (GameManager.startGame == true && GameManager.gamestarted == false)
        {
            rb.AddForce(transform.up * 400f);
            rb.AddForce(transform.right * 250f);
            GameManager.gamestarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block") 
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Losewall")
        {
            Destroy(this.gameObject);
        }


    }
}

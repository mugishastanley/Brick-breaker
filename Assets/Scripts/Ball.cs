using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    SpriteRenderer sprite;
    public int countRed { get; set; }
    public int countGreen { get; set; }
    public int countBlue{get; set;} 
    public int countBlocksDestroyed { get; set; }

    public bool lost  { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        lost = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement() {
        if (GameManager.startGame && GameManager.gamestarted == false)
        {
            rb.AddForce(transform.up * 400f);
            rb.AddForce(transform.right * 250f);
            GameManager.gamestarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Red")) 
        {
            if (gameObject != null)
            {
                sprite = gameObject.GetComponent<SpriteRenderer>();
                countRed++;
                countBlocksDestroyed++;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Green"))
        {
            if (gameObject != null)
            {
                sprite = gameObject.GetComponent<SpriteRenderer>();
                countGreen++;
                countBlocksDestroyed++;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Blue"))
        {
            if (gameObject != null)
            {
                sprite = gameObject.GetComponent<SpriteRenderer>();
                countBlue++;
                countBlocksDestroyed++;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Losewall"))
        {
            lost = true;
            if ( gameObject != null)
            {
                // Destroy(this.gameObject);
                sprite = gameObject.GetComponent<SpriteRenderer>();
                sprite.color = new Color(0f, 0f, 0f);
            }
        }



    }
}

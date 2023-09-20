using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // Start is called before the first frame update
    public Camera mainCamera;
    float maxleft = 8.0f;
    float maxright = -8.0f;

    void Start()
    {
        //mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        movement2();

    }

    void movement() {
        float maxmovement = Mathf.Clamp(Input.mousePosition.x, maxleft, maxright);
        float worldxpos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)).x;
        this.transform.position = new Vector3(worldxpos, -4.5f, 0);
    }

    void movement2() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-12f * Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(12f * Time.deltaTime,0,0);
        }
    }
}

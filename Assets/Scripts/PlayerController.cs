﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private bool isFalling;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movement * speed);
        if (Input.GetKeyDown("space") && isFalling==false )
        {
            
            Vector3 jump = new Vector3(0.0f, 350.0f, 0.0f);

            GetComponent<Rigidbody>().AddForce(jump);
            
        }
        isFalling = true;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
            countText.text = "Score: " + count.ToString();
        
        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        isFalling = false;
    }

}
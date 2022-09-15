using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;

    public Rigidbody2D rb2D;

    void Update()
    {

        if (Input.GetKey(moveUp))
        {
            rb2D.MovePosition(transform.position + transform.up * speed);
            
        } else if (Input.GetKey(moveDown))
        {
            rb2D.MovePosition(transform.position + transform.up * -speed);
            
        }
    }

    public void UpdateColor(Color color)
    {
        GetComponent<Image>().color = color;
    }
}

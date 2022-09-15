using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBallController : MonoBehaviour
{
    public Vector3 speed = new Vector3(1, 1);
    public Vector2 randomSpeed = new Vector2(1, 3);

    Vector3 initialPosition;

    private bool canMode = false;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (canMode)
        {
            transform.Translate(speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float newSpeed = Random.Range(randomSpeed.x, randomSpeed.y);
            speed *= -1;
            
            if (speed.x < 0)
                newSpeed = -newSpeed;
            
            speed.x = newSpeed;

        } else
        {
            speed.y *= -1;
        }
        
    }

    public void ResetBall()
    {
        transform.position = initialPosition;
    }

    public void CanMode(bool state)
    {
        canMode = state;
    }
}

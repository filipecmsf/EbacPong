using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public string ballTag = "Ball";
    public bool player1 = true;
    public StateMachine stateMachine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == ballTag)
        {
            GameManager.instance.UpdateScore(player1Scored: player1);
            stateMachine.ResetPosition();
}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface para os estados do jogo
public class StateBase
{
    public virtual void OnStateEnter(object o = null)
    {
        Debug.Log("OnStateEnter");
    }

    public virtual void OnStateStay()
    {
        
    }

    public virtual void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }
}

public class StatePlaying: StateBase 
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        BaseBallController ball = (BaseBallController)o;

        GameManager.instance.StartGame(); 
    }
}

public class StateResetGame : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.instance.ResetGame();
    }
}

public class StateResetPosition : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.instance.ResetBallPosition();
    }
}

public class StateEnter: StateBase
{
    public override void OnStateEnter(object o)
    {
        base.OnStateEnter(o);
        GameManager.instance.ResetBallPosition();
    }
}

public class EndEnter : StateBase
{
    public override void OnStateEnter(object o)
    {
        base.OnStateEnter(o);
        GameManager.instance.EndGameSetup();
    }
}
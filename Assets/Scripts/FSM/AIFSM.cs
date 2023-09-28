using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ҪFSM���������������±���ֵ
/// State�б�: Idle, Chase
/// </summary>
[System.Serializable]
public class AIFSM : FSM
{
    public Transform CurTarget;
    public float MoveSpeed;
    public Transform SelfTrans;

    public AIFSM()
    {
        AddState(new IdleState("Idle",this));
        AddState(new ChaseState("Chase", this));
    }
}

public abstract class AIState : State
{
    protected AIFSM m_CurFSM;

    public AIState(string name, AIFSM FSM) : base(name, FSM)
    {
        m_CurFSM = FSM;
    }
}

public class IdleState : AIState
{
    public IdleState(string name, AIFSM FSM) : base(name, FSM)
    {
        
    }

    public override void OnEnter()
    {

        Debug.Log("����Idle");
    }

    public override void OnExit()
    {
        Debug.Log("�˳�Idle");
    }

    public override void OnUpdate()
    {
        Debug.Log("����Idle");
    }
}

public class ChaseState : AIState
{
    public ChaseState(string name, AIFSM FSM) : base(name, FSM)
    {
        
    }

    public override void OnEnter()
    {
        
        Debug.Log("����Chase");
    }

    public override void OnExit()
    {
        Debug.Log("�˳�Chase");
    }

    public override void OnUpdate()
    {
        m_CurFSM.SelfTrans.position = Vector3.MoveTowards(m_CurFSM.SelfTrans.position, m_CurFSM.CurTarget.position, m_CurFSM.MoveSpeed * Time.deltaTime);
        Debug.Log("����Chase");
    }
}


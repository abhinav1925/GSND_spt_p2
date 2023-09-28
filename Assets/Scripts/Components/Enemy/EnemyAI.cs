using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    protected bool m_IsPlayerInView;
    public Transform FollowTarget;

    [SerializeField]
    private NavMeshAgent m_Agent;
    [SerializeField]
    private Animator m_Anim;

    public bool IsPlayerInView
    {
        get { return m_IsPlayerInView; }
        set { m_IsPlayerInView = value; }
    }

    private int Anim_HasTarget;

    private void Awake()
    {
        Anim_HasTarget = Animator.StringToHash("HasTarget");
    }

    private void Update()
    {
        UpdateAnim();
        KeepFollowingTarget();
    }

    public void KeepFollowingTarget()
    {
        if(IsPlayerInView)
            m_Agent.SetDestination(FollowTarget.position);
    }

    private void UpdateAnim()
    {
        m_Anim.SetBool(Anim_HasTarget, IsPlayerInView);
    }
}

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

    public Transform[] PatrolPoints;
    public float PatrolIntervalDelay;
    private int PatrolIndex;

    public bool IsPlayerInView
    {
        get { return m_IsPlayerInView; }
        set { m_IsPlayerInView = value; }
    }

    private int Anim_IsMoving;
    private bool IsPatroling;

    private void Awake()
    {
        Anim_IsMoving = Animator.StringToHash("IsMoving");
    }

    private void Update()
    {
        UpdateAnim();
        KeepFollowingTarget();
    }

    public void KeepFollowingTarget()
    {
        if(IsPlayerInView)
        {
            m_Agent.SetDestination(FollowTarget.position);
            StopCoroutine(PatrolCou());
            IsPatroling = false;
        }
        else
        {
            if(!IsPatroling)
            {
                StartCoroutine(PatrolCou());
            }
        }
    }

    private IEnumerator PatrolCou()
    {
        m_Agent.SetDestination(PatrolPoints[PatrolIndex].position);
        IsPatroling = true;
        yield return new WaitUntil(() => Vector3.Distance(transform.position, PatrolPoints[PatrolIndex].position) <= m_Agent.stoppingDistance);
        Debug.Log("Reach Patrol Point");
        yield return new WaitForSeconds(PatrolIntervalDelay);
        IsPatroling = false;
        PatrolIndex++;
        if(PatrolIndex>=PatrolPoints.Length)
        {
            PatrolIndex = 0;
        }
    }

    private void UpdateAnim()
    {
        if(IsPlayerInView || m_Agent.velocity.sqrMagnitude>0.5f)
        {
            m_Anim.SetBool(Anim_IsMoving, true);
        }
        else
        {
            m_Anim.SetBool(Anim_IsMoving, false);
        }
    }
}

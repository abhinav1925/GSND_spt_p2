using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ITrigger : MonoBehaviour
{
    public bool TriggerOnce;
    public UnityEvent OnPlayerTriggerEvt;
    public UnityEvent OnPlayerTriggerEnterEvt;
    public UnityEvent OnPlayerTriggerExitEvt;

    public bool HasTriggered { get; set; }
    public bool IsPlayerInTrigger { get; set; }

    protected Transform PlayerTrans;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.CompareTag("Player"))
        {
            PlayerTrans = other.transform.root;
            IsPlayerInTrigger = true;
            OnPlayerEnterTrigger();

            if (!TriggerOnce ||(TriggerOnce && !HasTriggered))
            {
                OnPlayerTrigger();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            PlayerTrans = null;
            IsPlayerInTrigger = false;
            OnPlayerExitTrigger();
        }
    }

    protected virtual void OnPlayerTrigger()
    {
        OnPlayerTriggerEvt?.Invoke();
    }

    protected virtual void OnPlayerEnterTrigger()
    {
        OnPlayerTriggerEnterEvt?.Invoke();
    }

    protected virtual void OnPlayerExitTrigger()
    {
        OnPlayerTriggerExitEvt?.Invoke();
    }

    public void ResetTrigger()
    {
        HasTriggered = false;
    }
}

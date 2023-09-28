using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    [SerializeField] private Animator doorAni;
    [SerializeField] private int Ani_DoorOpen;


    public Key.KeyType GetKeyType()
    {
        return keyType;
    }


    public void Awake()
    {
        Ani_DoorOpen = Animator.StringToHash("DoorOpen");
    }


    public void OpenDoor()
    {
        gameObject.SetActive(false);
        doorAni.SetTrigger(Ani_DoorOpen);
    }
}



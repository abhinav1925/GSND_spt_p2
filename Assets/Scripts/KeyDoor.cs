using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;



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
        //gameObject.SetActive(false);
        doorAni.SetBool("isOpen", true);
        if(keyType == Key.KeyType.badKey)
        {
            SceneManager.LoadScene("Success_End");
        }
    }


   
}



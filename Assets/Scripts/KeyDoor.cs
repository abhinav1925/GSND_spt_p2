using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;



public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    [SerializeField] private Animator doorAni;
    [SerializeField] private int Ani_DoorOpen;
    private AudioSource audio;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


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
        play_sound();
        if(keyType == Key.KeyType.badKey)
        {
            StartCoroutine(LoadendScene());
     
        }
    }

    public void play_sound()
    {
        audio.Play();
    }

    IEnumerator LoadendScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Success_End");
    }
   
}



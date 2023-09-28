using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }


    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added key: " + keyType);
        keyList.Add(keyType);
    }


    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }


    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }


    private void OnTriggerEnter(Collider collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            playSound();
            Destroy(key.gameObject);
        }


        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }

        }


        if (collider.gameObject.tag == "Zombie")
        {
            SceneManager.LoadScene("Fail_End");
        }
    }

    private void playSound()
    {
        audio.Play();
    }


}


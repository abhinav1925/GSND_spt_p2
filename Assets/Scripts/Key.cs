using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        goodKey,
        badKey
    }


    public KeyType GetKeyType()
    {
        return keyType;
    }
}


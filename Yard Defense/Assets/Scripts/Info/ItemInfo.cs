using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [Serializable]
    public enum ItemType
    {
        Collar,
        Toy
    }

    [SerializeField] ItemType itemType;

}

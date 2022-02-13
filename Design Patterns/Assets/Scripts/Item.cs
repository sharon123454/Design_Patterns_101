using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EKey { BlackKey, BlueKey, RedKey, GreenKey };
[System.Serializable]
public class Item
{
    public GameObject prefab;
    public Sprite sprite;
    public EKey eKey;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ELock { Door, Other};
public class Unlockable : MonoBehaviour
{
    public EKey eKey;
    public ELock eLock;
    [SerializeField] private Transform keyPos;
    
    public void OpenLock(GameObject keyObj)
    {
        keyObj.transform.position = keyPos.position;
        keyObj.transform.rotation= keyPos.rotation;

        Debug.Log($"{gameObject.name} was opened");
    }
}
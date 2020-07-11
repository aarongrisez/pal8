using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public abstract class BaseManager : MonoBehaviour
{
    PlayerController controller;

    private void Awake() 
    {
        controller = GetComponent<PlayerController>();
    }

    public virtual void ClearAllCollections() {}

}

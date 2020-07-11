using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Entrypoint component on a Player object    
[RequireComponent(typeof(SceneManager))]
public class SceneController : MonoBehaviour
{
    [HideInInspector] public SceneManager sceneManager;

    void Awake()
    {
        sceneManager = GetComponent<SceneManager>();
        Debug.Log("SceneController mounted");
    }

}
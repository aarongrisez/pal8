using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    public InputField inputField;

    void Awake()
    {
        inputField.onEndEdit.AddListener(HandleEnter);
    }

    void Start()
    {
        inputField.ActivateInputField();
    }

    void HandleEnter(string text)
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}


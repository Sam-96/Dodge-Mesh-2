﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenuThree : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenuFour : MonoBehaviour
{

    public void SinglePlayer()
    {
        SceneManager.LoadScene("MainMesh");
    }

    public void MultiPlayer()
    {
        SceneManager.LoadScene("NetworkScene");
    }
}


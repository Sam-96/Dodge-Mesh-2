using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ControlMenuThree : MonoBehaviour
{

    public void GoBack()
    {
        SceneManager.LoadScene("Modes");
        //NetworkManager.singleton.ServerChangeScene("Modes");
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ControlMenuThree : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("LobbyScene");
        //NetworkManager.singleton.ServerChangeScene("Modes");
    }

}


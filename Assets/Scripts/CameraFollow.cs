﻿using UnityEngine;
using UnityEngine.Networking;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public int depth = -20;

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + new Vector3(0, 10, depth);
        }
    }

    public void SetTarget(Transform target)
    {
        playerTransform = target;
    }
}
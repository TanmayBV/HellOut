using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float Speed = 2f;
    void Start()
    {
        
    }

    
    void Update()
    {
       transform.Translate(Vector3.right *Speed *Time.deltaTime);
    }
}

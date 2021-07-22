using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float Speed = 2f;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Youlose_;
    [SerializeField] float Offsets;

    private float CurrentPlayer_Dis, CurrentCamera_Dis;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        CurrentPlayer_Dis = Player.transform.position.x;
        CurrentCamera_Dis = gameObject.transform.position.x;

       CheckPlayerDistance();
       transform.Translate(Vector3.right *Speed *Time.deltaTime);
    }

    void CheckPlayerDistance()
    {
        if (CurrentPlayer_Dis + Offsets < CurrentCamera_Dis)
        {
            Destroy(Player);
            Youlose_.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

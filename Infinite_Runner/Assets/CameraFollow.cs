using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float Speed = 2f;
    [SerializeField] GameObject Player_Blue;
    [SerializeField] GameObject Player_Red;
    [SerializeField] GameObject Youlose_;
    [SerializeField] float Offsets;

	#region Player_Blue
	private float CurrentPlayer_Dis, CurrentCamera_Dis;
    private float CurrentPlayer_DisY, CurrentCamera_DisY;
	#endregion

	#region Player_red
	private float CurrentPlayer_Red_Dis, CurrentCamera_Red_Dis;
    private float CurrentPlayer_Red_DisY, CurrentCamera_Red_DisY;
    #endregion
    void Start()
    {
        Time.timeScale = 1;
    }


    void Update()
    {
        #region Calulating_Distance_Player_Blue
        CurrentPlayer_Dis = Player_Blue.transform.position.x;
        CurrentCamera_Dis = gameObject.transform.position.x;

        CurrentPlayer_DisY = Player_Blue.transform.position.y;
        #endregion

        #region Calulating_Distance_Player_Red
        CurrentPlayer_Red_Dis = Player_Red.transform.position.x;
        CurrentCamera_Red_Dis = gameObject.transform.position.x;

        CurrentPlayer_Red_DisY = Player_Red.transform.position.y;
        #endregion

        CheckPlayerDistance();
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    void CheckPlayerDistance()
    {
        if (CurrentPlayer_Dis + Offsets < CurrentCamera_Dis || CurrentPlayer_DisY  < -6.56f || CurrentPlayer_DisY > 4.66f)
        {
            //Destroy(Player_Blue);
            Player_Blue.SetActive(false);
            Youlose_.SetActive(true);
            Time.timeScale = 0;
        }

        if (CurrentPlayer_Red_Dis + Offsets < CurrentCamera_Dis || CurrentPlayer_Red_DisY < -6.56f || CurrentPlayer_Red_DisY >4.66f)
        {
            //Destroy(Player_Red);
            Player_Red.SetActive(false);
            Youlose_.SetActive(true);
            Time.timeScale = 0;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    private Ads_Manager ads;

    void Start()
    {
        ads = FindObjectOfType<Ads_Manager>();
        if (ads.instruction > 0)
        {
            gameObject.SetActive(false);
            timer.SetActive(true);
        }
    }
}

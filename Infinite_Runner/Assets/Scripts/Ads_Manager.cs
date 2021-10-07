
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;
using UnityEngine.Advertisements;
using UnityEngine;

public class Ads_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _Instruction;
    public static Ads_Manager _Instacnce;
    public int instruction;
    public int lives;
    public bool adsPlaying=false;
    private void Awake()
   {
       _Instruction = GameObject.Find("Instruction_panal");
       if (_Instacnce == null)
       {
           _Instacnce = this;
       }
       else
       {
           Destroy(gameObject);
       }
       
       DontDestroyOnLoad(this.gameObject);
   }
    private void Start()
   {
       Advertisement.Initialize("4394009");
   }
    private void Update()
    {
        PlayerPrefs.SetInt("Tries",lives);
        
        if (lives > 3 && !adsPlaying)
        {
            adsPlaying = true;
            PlayAd(); 
            lives = 0;
        }
    }

    public void PlayAd()
    {
        if(Advertisement.IsReady("Video"))
        {
            Advertisement.Show("Video");
        } 
    }
    
}

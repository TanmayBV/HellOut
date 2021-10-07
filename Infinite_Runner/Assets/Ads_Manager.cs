
using System;
using System.Collections;
using System.ComponentModel.Design;
using UnityEngine.Advertisements;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    [SerializeField] private GameObject afterDeath;
    
   public int lives;

   private void Awake()
   {
       DontDestroyOnLoad(this.gameObject);
       afterDeath = GameObject.Find("AfterDeath_Menu");
   }

   private void Start()
   {
       Advertisement.Initialize("4394009");
   }

    private void Update()
    {
        PlayerPrefs.SetInt("Tries",lives);
        if (PlayerPrefs.GetInt("Tries", 0)>4)
        {
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

    public void ShowBanner()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        }
        else
        {
            StartCoroutine(RepeatBaner());
        }
    }

    public void Hidebaner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatBaner()
    {
        yield return new WaitForSeconds(1f);
        ShowBanner();
    }
}

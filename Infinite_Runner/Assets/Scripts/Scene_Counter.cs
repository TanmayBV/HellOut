using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Counter : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private float _Timer=5;
    
    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (_Timer > 0)
        {
            _Timer -= 0.02f;
            _timerText.text = math.round(_Timer).ToString();
            if (_Timer<1)
            {
                _timerText.text = "RUN !";
            }
        }
        else
        {
            gameObject.SetActive(false);
            _timerText.enabled = false;
            Time.timeScale = 1;
        }
    }
}

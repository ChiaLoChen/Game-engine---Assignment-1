using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class timer : singleton<timer>
{
    [SerializeField]
    private float _CurrentTime;
    private float _baseTime = 0.0f;
    private float _maxTime = 100.00f;
   

    public TextMeshProUGUI _timerText;
    float time;

    public enum timerType { timer, countdown };
    public timerType _timerType;

    public bool canCount = false;
    bool ended = false;


    // Start is called before the first frame update
    void Start()
    {

        _timerText = GameObject.Find("timerText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canCount)
        {
            switch (_timerType)
            {
                case timerType.timer:

                    _CurrentTime = _baseTime += Time.deltaTime;
                    time = _CurrentTime;

                    break;
                case timerType.countdown:

                    _CurrentTime = _maxTime -= Time.deltaTime;
                    time = _CurrentTime;

                    if(time <= 0)
                    {
                        ended = true;
                    }

                    break;
            }

            if (ended)
            {
                canCount = false;
            }
        }
        
        

        _timerText.text = time.ToString("0.0");

    }

    public void swapTimer(string type)
    {
        switch (type)
        {
            case "timer":
                _CurrentTime = 0;
                _baseTime = 0;
                _timerType = timerType.timer;
                break;
            case "countdown":
                _CurrentTime = 0;
                _maxTime = 100;
                _timerType = timerType.countdown;
                break;
        }
    }


    public float getTime()
    {
        return _CurrentTime;
    }
    void OnApplicationQuit()
    {
        
        Debug.Log("You have played: "+Math.Round(_CurrentTime, 2)+" seconds");
    }
}

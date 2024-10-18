using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : singleton<timer>
{
    [SerializeField]
    private float _CurrentTime;
    private float _baseTime = 0.0f;
    private float _maxTime = 100.00f;
   

    public TextMeshProUGUI _timerText;
    int time;

    public enum timerType { timer, countdown };
    public timerType _timerType;


    // Start is called before the first frame update
    void Start()
    {

        _timerText = GameObject.Find("timerText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(_timerType){
            case timerType.timer:
                
                _CurrentTime = _baseTime += Time.deltaTime;
                time = (int)_CurrentTime;

                break;
            case timerType.countdown:

                _CurrentTime = _maxTime -= Time.deltaTime;
                time = (int)_CurrentTime;

                break;
        }
        

        _timerText.text = time.ToString();
    }

    void swapTimer(string type)
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
}

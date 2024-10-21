using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static timer;

public class timerSelection : MonoBehaviour
{
    public enum timerModes {countdown, timetrial }

    PlayerMovement _player;
    CameraFollow _camera;
    enemySpawner _spawner;


    private void Awake()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _player = FindObjectOfType<PlayerMovement>();
        _camera = FindObjectOfType<CameraFollow>();
        _spawner = FindObjectOfType<enemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTimeMode(string type)
    {
        if (type == "countdown")
        {
            timer.Instance.swapTimer("countdown");
        }
        else if (type == "timer")
        {
            timer.Instance.swapTimer("timer");
        }

        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _camera.started = true;
        _player.started = true;
        _spawner.started = true;
    }
}

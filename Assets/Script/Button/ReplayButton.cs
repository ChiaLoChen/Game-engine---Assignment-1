using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButton : MonoBehaviour
{
    public void Replay()
    {
        Debug.Log("Replay");
        InputHandler inputHandler = FindObjectOfType<InputHandler>();
        inputHandler.Replay();
    }
}
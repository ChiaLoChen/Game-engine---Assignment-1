using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    int score = 0;
    void OnGUI()
    {
        //score = 
        GUILayout.BeginArea(
            new Rect(50, 50, 100, 2000));
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("score: "+score);
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.BeginArea(
            new Rect(50, 50, 100, 2000));
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("score");
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}

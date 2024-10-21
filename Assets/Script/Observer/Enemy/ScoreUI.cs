using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour, EnemyObserver
{
    int score = 0;
    public int maxScore = 3;
    public void Subscribe(GameObject enemyObject)
    {
        EnemyMovement enemy = enemyObject.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.AddObserver(this);
        }
    }
    public void OnHealthChanged(int newHealth)
    {
        Debug.Log($"Enemy health changed: {newHealth}");
        // Optionally update the UI with new health
    }

    public void OnEnemyDeath()
    {
        score += Random.Range(1, maxScore);
        Debug.Log($"Enemy defeated! Score: {score}");
        // Update the score UI here if needed
    }
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
}

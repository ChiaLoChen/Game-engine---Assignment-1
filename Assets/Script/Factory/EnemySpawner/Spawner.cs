using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    private ScoreUI scoreManager;
    void Start()
    {
        scoreManager = GetComponent<ScoreUI>(); 
    }
    public void spawn(Vector3 pos)
    {
        GameObject newEntity = Instantiate(createEntity(), pos, Quaternion.identity);
        scoreManager.Subscribe(newEntity);
    }

    public abstract GameObject createEntity();

}


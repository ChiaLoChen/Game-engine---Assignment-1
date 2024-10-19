using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> _spawns = new List<Transform>();

    [SerializeField]
    GameObject _enemyPrefab;

    int randomNum;
    
    void Start()
    {

        //check for children that are spawn locations then add them to the list

        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            Transform currentObject = this.gameObject.transform.GetChild(i);
            if (currentObject.tag == "SpawnLocation")
            {
                _spawns.Add(currentObject);
            }
        }

    }

    void Update()
    {



        //if current time is divisible by 10, summon an enemy

        //Spawns like 5 enemies every batch, unintended but maybe keep

        double time = Math.Round(timer.Instance.getTime(), 2);

        if(time % 10 == 0 && time != 0)
        {
            spawnEnemyInPosition(_spawns);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            spawnEnemyInPosition(_spawns);
        }
    }


    //creates a random number then spawns an enemy at the transform in the index of that random number
    void spawnEnemyInPosition(List<Transform> tArray)
    {
        randomNum = Random.Range(0, _spawns.Count);
        spawnEnemy(tArray[randomNum]);
    }

    //spawns enemy at given transform
    void spawnEnemy(Transform t)
    {
        Instantiate(_enemyPrefab, t);
    }
}

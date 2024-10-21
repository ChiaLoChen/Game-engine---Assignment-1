using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public void spawn(Vector3 pos)
    {
        GameObject newEntity = createEntity();

        Instantiate(newEntity, pos, Quaternion.identity);
    }

    public abstract GameObject createEntity();

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : LabrynthCreation
{
    public override void Create(Vector3 position, GameObject prefab)
    {
        GameObject wall = GameObject.Instantiate(prefab, position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : LabrynthCreation
{
    public override void Create(Vector3 position, GameObject wallPrefab)
    {
        GameObject wall = GameObject.Instantiate(wallPrefab, position, Quaternion.identity);
    }
}
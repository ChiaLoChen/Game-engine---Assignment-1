using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Generator : MonoBehaviour
{
	public GameObject wall;
	public GameObject path;
    public GameObject enemySpawn;
    public int width = 10;
    public int height = 10;
    public int gapsize = 2;
    private bool[,] visited;

    void Start()
    {
        GenerateLabyrinth(width, height);
        
        //create 10 enemySpawn and randomly distribute them through out the map
        for (int i = 0; i < 10; i++)
        {
            CreateElement(Random.Range(1, height), Random.Range(1, width), "enemySpawn");
        }
    }

    public void GenerateLabyrinth(int width, int height)
    {
        this.width = width;
        this.height = height;
        visited = new bool[width, height];

        int startX = Random.Range(1, width / 2) * 2;
        int startY = Random.Range(1, height / 2) * 2;
        GeneratePath(startX, startY);
    }
    private void GeneratePath(int x, int y)
    {
        visited[x, y] = true;

        List<Vector2Int> directions = new List<Vector2Int>
        {
            new Vector2Int(2, 0), // Right
            new Vector2Int(-2, 0), // Left
            new Vector2Int(0, 2), // Up
            new Vector2Int(0, -2) // Down
        };

        Shuffle(directions);

        foreach (var direction in directions)
        {
            int newX = x + direction.x;
            int newY = y + direction.y;

            if (newX >= 0 && newX < width && newY >= 0 && newY < height && !visited[newX, newY])
            {
                CreateElement(x + direction.x / 2, y + direction.y / 2, "Wall");
                GeneratePath(newX, newY);
            }
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                CreateElement(i, j, "Path");
            }
        }

    }
    private void CreateElement(int x, int y, string type)
    {
        LabrynthCreation element = new Wall();
        if (type == "Wall")
        {
            Vector3 position = new Vector3(x * gapsize, 2, y * gapsize);
            element?.Create(position, wall);
        }
        else if(type == "Path"){
            Vector3 position = new Vector3(x * gapsize, 0, y * gapsize);
                element?.Create(position, path);
        }
        else if(type == "enemySpawn")
        {
            Vector3 position = new Vector3(x * gapsize, 0, y * gapsize);
            element?.Create(position, enemySpawn);
        }
    }

    private void Shuffle(List<Vector2Int> directions)
    {
        for (int i = directions.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            var temp = directions[i];
            directions[i] = directions[j];
            directions[j] = temp;
        }
    }
}
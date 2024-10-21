using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Generator : singleton<Generator>
{
	public GameObject wall;
	public GameObject floor;
    public GameObject enemySpawn;
    public int width = 10;
    public int height = 10;
    public int gapsize = 2;
    private bool[,] visited;
    private List<Vector2Int> directions;

    void Start()
    {
        visited = new bool[width, height];
        directions = new List<Vector2Int>
        {
            new Vector2Int(2, 0), // Right
            new Vector2Int(-2, 0), // Left
            new Vector2Int(0, 2), // Up
            new Vector2Int(0, -2) // Down
        };
        GenerateLab(0, 0);
        
        //create 10 enemySpawn and randomly distribute them through out the map
        for (int i = 0; i < 10; i++)
        {
            CreateElement(Random.Range(1, height), Random.Range(1, width), "enemySpawn", Quaternion.identity, 0);
        }

        CreateOutsideWall();
    }
    private void GenerateLab(int x, int y)
    {
        visited[x, y] = true;
        foreach (var direction in directions)
        {
            int newX = x + direction.x;
            int newY = y + direction.y;

            if (newX >= 0 && newX < width && newY >= 0 && newY < height && !visited[newX, newY])
            {
                CreateElement(x + direction.x / 2, y + direction.y / 2, "Wall", Quaternion.identity, 0);
                GenerateLab(newX, newY);
            }
        }
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                CreateElement(i, j, "Floor", Quaternion.identity, 0);
            }
        }

    }
    
    private void CreateElement(int x, int y, string type, Quaternion rotation, int closer)
    {
        LabrynthCreation element = new Wall();
        Vector3 position = new Vector3(x * gapsize, 0, y * gapsize);
        if (type == "Wall")
        {
            position.y = 2; 
            Instantiate(wall, position, Quaternion.identity);
        }
        else if(type == "Floor")
        {
            Instantiate(floor, position, Quaternion.identity);
        }
        else if(type == "enemySpawn")
        {
            Instantiate(enemySpawn, position, Quaternion.identity);
        }
        else if (type == "OutsideWall")
        {
            position.y = 2;
            position.x += closer;
            position.z += closer;
            Instantiate(wall, position, rotation);
        }
    }
    private void CreateOutsideWall()
    {
        //create top and bottom wall in each column
        for (int i = -1; i <= width; i++)
        {
            CreateElement(i, -1, "OutsideWall", Quaternion.identity, 5); // Bottom wall
            CreateElement(i, height, "OutsideWall", Quaternion.identity, -5); // Top wall
        }
        //create left and right wall in each row
        for (int j = -1; j <= height; j++)
        {
            CreateElement(-1, j, "OutsideWall", Quaternion.Euler(0, 90, 0), 5); // Left wall
            CreateElement(width, j, "OutsideWall", Quaternion.Euler(0, 90, 0), -5); // Right wall
        }
    }
}
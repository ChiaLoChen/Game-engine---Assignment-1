using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	public GameObject wall;
	public GameObject path;
    public int width = 10;  // Default width, can be set in the Inspector
    public int height = 10; // Default height, can be set in the Inspector
    public int gapsize = 2;
    private bool[,] visited;

    void Start()
    {
        GenerateLabyrinth(width, height);
    }

    public void GenerateLabyrinth(int width, int height)
    {
        if (width <= 0 || height <= 0)
        {
            Debug.LogError("Width and height must be greater than zero.");
            return;
        }

        this.width = width;
        this.height = height;
        visited = new bool[width, height];

        // Start generating from a random point
        int startX = Random.Range(0, width / 2) * 2;
        int startY = Random.Range(0, height / 2) * 2;
        GeneratePath(startX, startY);
        
        // Create walls around the labyrinth
        CreateWalls();
    }
private void CreateWalls()
{
    for (int i = 0; i < width; i++)
    {
        for (int j = 0; j < height; j++)
        {
            if (!visited[i, j]) // If the cell was not visited
            {
                CreateElement(i, j, "Wall"); // Create a wall at this position
            }
        }
    }
}
    private void GeneratePath(int x, int y)
    {
        visited[x, y] = true;

        // Randomize directions
        List<Vector2Int> directions = new List<Vector2Int>
        {
            new Vector2Int(1, 0), // Right
            new Vector2Int(-1, 0), // Left
            new Vector2Int(0, 1), // Up
            new Vector2Int(0, -1) // Down
        };

        Shuffle(directions);

        foreach (var direction in directions)
        {
            int newX = x + direction.x * 2;
            int newY = y + direction.y * 2;

            if (IsInBounds(newX, newY) && !visited[newX, newY])
            {
                // Create a path between the current and new position
                CreateElement(x + direction.x, y + direction.y, "Path");
                GeneratePath(newX, newY);
            }
        }

        // Create walls around the labyrinth
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (!visited[i, j])
                {
                    CreateElement(i, j, "Wall");
                }
            }
        }
    }

    private bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    private void CreateElement(int x, int y, string type)
    {
        Vector3 position = new Vector3(x * gapsize, 0, y * gapsize);
        LabrynthCreation element = new Wall();
        if (type == "Wall")
        {
            element?.Create(position, wall);
        }
        else if(type == "Path"){
                element?.Create(position, path);
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
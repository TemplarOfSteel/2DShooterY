using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTile : MonoBehaviour
{
    public static Dictionary<string, Vector2> dirs = new Dictionary<string, Vector2>
    {
        { "east", Vector2.right},
        { "west", Vector2.left},
        { "north", Vector2.up},
        { "south", Vector2.down}
    };


    bool openWest, openEast, openNorth, openSouth;
    public Vector2 tilePos;
    public Vector3 worldPos;

    public List<GameObject> damagablePrefabs;
    public GameObject wallPrefab; //20th of a floor tile

    int squareSide = 20;

    public void Setup(Vector2 tilePos)
    {
        this.tilePos = tilePos;
        worldPos = squareSide * tilePos;
        transform.position = worldPos;
    }

    public void GenerateWalls()
    {
        GenerateWall(0, squareSide - 1);
        GenerateWall(0, 0);
        GenerateWall(squareSide - 1, 0);
        GenerateWall(squareSide - 1, squareSide - 1);

        if(!openEast)
        {
            for(int i = 1; i<squareSide - 1;i++)
            {
                GenerateWall(squareSide - 1, i);
            }
        }

        if (!openWest)
        {
            for (int i = 1; i < squareSide - 1; i++)
            {
                GenerateWall(0, i);
            }
        }

        if (!openNorth)
        {
            for (int i = 1; i < squareSide - 1; i++)
            {
                GenerateWall(i, squareSide - 1);
            }
        }

        if (!openSouth)
        {
            for (int i = 1; i < squareSide - 1; i++)
            {
                GenerateWall(i, 0);
            }
        }
    }

    private void GenerateWall(int x, int y)
    {
        var go = GameObject.Instantiate(wallPrefab, new Vector3(
            worldPos.x - squareSide / 2 + 0.5f + x,
            worldPos.y - squareSide / 2 + 0.5f + y,
            0),
            Quaternion.identity);

        go.name += "_" + tilePos.ToString() + "_" + x + ":" + y;
    }

    public void ConnectTo(LevelTile other)
    {
        foreach(var dir in dirs)
        {
            if(tilePos + dir.Value == other.tilePos)
            {
                switch(dir.Key)
                {
                    case ("east"):
                        openEast = true;
                        other.openWest = true;
                        break;

                    case ("west"):
                        openWest = true;
                        other.openEast = true;
                        break;

                    case ("north"):
                        openNorth = true;
                        other.openSouth = true;
                        break;

                    case ("south"):
                        openSouth = true;
                        other.openNorth = true;
                        break;
                }
            }
        }
    }
}

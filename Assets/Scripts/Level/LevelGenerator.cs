using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public LevelTile tilePrefab;
    public int tilesToGenerate = 15;

    void Start()
    {
        StaticLevelGenerator.GenerateLevel(tilePrefab, tilesToGenerate);
    }
}



public static class StaticLevelGenerator
{


    public static void GenerateLevel(LevelTile tilePrefab, int tilesToGenerate)
    {
        List<LevelTile> tiles = new List<LevelTile>();
        tiles.Add(GenerateTile(tilePrefab, Vector2.zero));

        while(tiles.Count < tilesToGenerate)
        {
            var randTile = tiles[Random.Range(0, tiles.Count)];
            var randDir = LevelTile.dirs.Values.ToList()[Random.Range(0, 4)];
            var newTilePos = randTile.tilePos + randDir;

            if(!tiles.Any( t => t.tilePos == newTilePos))
            {
                var newTile = GenerateTile(tilePrefab, newTilePos);
                tiles.Add(newTile);
                randTile.ConnectTo(newTile);
            }
        }

        foreach(var tile in tiles)
        {
            tile.GenerateWalls();
        }
    }

    private static LevelTile GenerateTile(LevelTile tilePrefab, Vector2 tilePos)
    {
        LevelTile tile = GameObject.Instantiate(tilePrefab);
        tile.Setup(tilePos);
        return tile;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinder : MonoBehaviour {

    struct CellState{
        public float score;
        public Tile previous;
    }

    static CellState[,] grid = new CellState[Field.Width, Field.Height];
    static Field field;
    static Tile from;
    static Tile to;
    
    public static void ShortestPath(Field _field, Tile _from, Tile _to)
    {

        if (_from == null || _to == null)
            return;

        field = _field;
        from = _from;
        to = _to;

        ResetGrid();
       
       

        RecursivePass(from);
        if (CheckPath())
            PrintPathLength();
    }

    static private bool CheckPath()
    {
        for (Tile t = to; t != from; t = grid[t.x, t.y].previous)
        {
            if (t == null)
            {
                Debug.Log("Check failed");
                return false;
            }
        }

        return true;

    }
    static void PrintPath()
    {
        for (Tile t = to; t != null; t = grid[t.x, t.y].previous)
        {
            Debug.Log("X: " + t.x + ", Y: " + t.y);
        }

    }
    static void PrintPathLength()
    {
        float length = 0;
        for (Tile t = to; t != null; t = grid[t.x, t.y].previous)
        {
            length++;
        }
        Debug.Log("Length = " + length);
    }


    static void RecursivePass(Tile current)
    {
        foreach (Tile near in NearTiles(current)){

            float new_score = grid[current.x, current.y].score + 1.0f;
            float old_score = grid[near.x, near.y].score;

            if (new_score < old_score)
            {
                grid[near.x, near.y].score = new_score;
                grid[near.x, near.y].previous = current;
                RecursivePass(near);
            }
        }
    }

    private static void ResetGrid()
    {
        for (int x = 0; x < Field.Width; x++)
        {
            for (int y = 0; y < Field.Width; y++)
            {
                grid[x, y].score = 999999;
                grid[x, y].previous = null;
            }
        }
        grid[from.x, from.y].score = 0;
        
    }


    static List<Tile> NearTiles(Tile center)
    {
        //Return list of the near tiles.
        //If the tile is not present or unavailable
        //is discarded by AddNearTile
        List<Tile> tiles = new List<Tile>();
        AddNearTile(tiles, center.x, center.y - 1);
        AddNearTile(tiles, center.x, center.y + 1);
        AddNearTile(tiles, center.x - 1, center.y);
        AddNearTile(tiles, center.x + 1, center.y);
        return tiles;
    }

    static bool AddNearTile(List<Tile> tiles, int x, int y)
    {
        //Add tile to the list if exists, is available 
        //and so on

        if (x < 0 || y < 0)
            return false;

        if (x >= Field.Width || y >= Field.Height)
            return false;

        if (field.grid[x, y] == null)
            return false;

        if (field.grid[x, y].walkable == false)
            return false;

        tiles.Add(field.grid[x,y]);
        return true;
    }
}

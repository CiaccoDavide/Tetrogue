using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Field : MonoBehaviour
{

    //the field holds a single block
    private Block block;

    //Size of the field
    public readonly static short Width = 8;
    public readonly static short Height = 12;

    public Tile[,] grid = new Tile[Field.Width, Field.Height];
    /* USELESS LIST
    public List<Tile> tilesList = new List<Tile>();
    */
    //"Constructor"
    public static Field Create()
    {
        // Pool creation
        Tile.InitializePool();

        //Field creation
        GameObject field = Instantiate(Resources.Load("Prefabs/Field")) as GameObject;
        field.name = "Field";
        Field field_scr = field.GetComponent<Field>();

        //Block creation
        field_scr.block = Block.Create();
        field_scr.block.gameObject.transform.parent = field.transform;
        field_scr.block.field = field_scr;
        field_scr.block.ResetBlock();

        return field_scr;
    }
    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            block.MoveLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            block.MoveRight();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            block.MoveDown();
    }

    public void AddToGrid(Tile tile)
    {
        grid[tile.x, tile.y] = tile;
        tile.transform.parent = transform.Find("Relativo");
        /* USELESS LIST
        tilesList.Add(tile);
        */
        tile.SetPosition(tile.x, tile.y);
    }

    public void Collapse(int drop)
    {
        /* USELESS LIST
        for (int i = 0; i < tilesList.Count; i++)
        {
            if (tilesList[i].y < drop)
            {
                Pool.RecycleTile(tilesList[i]);
                tilesList.Remove(tilesList[i]);
                i--;
            }
        }

        foreach (Tile tile in tilesList)
        {
            tile.GoDown(drop);
            grid[tile.x, tile.y - drop] = grid[tile.x, tile.y];
            grid[tile.x, tile.y] = null;
        }*/

        for (int y = 0; y < Field.Height; y++)
        {
            for (int x = 0; x < Field.Width; x++)
            {
                if (y < drop)
                {
                    if (grid[x, y] != null)
                        Pool.RecycleTile(grid[x, y]);
                    grid[x, y] = null;
                }
                else
                {
                    if (grid[x, y] != null)
                        grid[x, y].GoDown(drop);
                    grid[x, y - drop] = grid[x, y];
                    grid[x, y] = null;
                }
            }
        }
        
    }
}

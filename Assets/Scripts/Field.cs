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
        tile.SetPosition(tile.x, tile.y);
    }

    public void Collapse(int drop)
    {

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

using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {

    //the field holds a single block
    private Block block; 

    //Size of the field
    public readonly static short Width = 8;
    public readonly static short Height = 12;


    public Tile[,] grid = new Tile[Field.Width, Field.Height];
    //"Constructor"
    public static Field Create()
    {
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
    public void HandleInput(){
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
        tile.transform.parent = gameObject.transform;
    }
}

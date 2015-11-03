using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour
{
    //Just a struct to hold x and y
    public struct Coords
    {
        public Coords(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public int x, y;
    }

    public enum Direction { Right, Left, Down }
    public enum Shape { Line, Cube, Stair, Cross, Serpent, Gun, Ufo, Abort, TotalNumber }

    //Blueprint dictionary that contains the informations to place tiles in a block.
    //Shape is the type of block, List<Coords> is the list of the offset of the tiles inside the block.
    //Everything is loaded from file
    public static Dictionary<Shape, List<Coords>> Blueprints = FileLoader.LoadBlocks();

   
    private List<Tile> tiles;   //List of tiles inside the block

    public Shape shape;         //Shape of the block

    private Coords coords;      //Position (in field coordinates)

    //"Constructor"
    public static Block Create()
    {
        GameObject block_go;
        block_go = Instantiate(Resources.Load("Prefabs/Block")) as GameObject;
        block_go.name = "Block";
        Block block_scr = block_go.GetComponent<Block>();
        block_scr.tiles = new List<Tile>();
        return block_scr;
    }

    //Reset the block to the top and creates new tiles.
    //TODO -> Use a pool instead of dynamic instantiation
    public void ResetBlock()
    {
        Tile temp_tile;
        //Create the tiles and position them
        Shape random_shape = (Shape)Random.Range(0, (int)Shape.TotalNumber);
        foreach (Coords off in Blueprints[random_shape])
        {
            temp_tile = Tile.Create();
            temp_tile.SetPosition(off.x, off.y);
            temp_tile.SetGround(Tile.grounds[0]);
            temp_tile.gameObject.transform.parent = transform;
            tiles.Add(temp_tile);
        }
        //Set the position at the top of the field in a random position.
        //Need a few optimization if the block is not 
        SetPosition(Random.Range(0,6),12);
    }

    //Set the position of the block.
    //The tiles move with it cause they are children
    private void SetPosition(int x, int y)
    {
        coords.x = x;
        coords.y = y;
        float conversion = Tile.TileSize * 1.0f / Global.PixelToUnit;
        transform.position = new Vector3((x - Field.FieldWidth / 2) * conversion, (y - Field.FieldHeight / 2) * conversion, 0);
    }
    
    public void AddTile(Tile tile)
    {
        tiles.Add(tile);
    }

    void MoveRight()
    {
        SetPosition(coords.x + 1, coords.y);
    }
    void MoveLeft()
    {
        SetPosition(coords.x - 1, coords.y);
    }
    void MoveDown()
    {
        SetPosition(coords.x, coords.y - 1);
    }
}

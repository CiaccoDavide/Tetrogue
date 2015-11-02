using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour
{

    //**Static informations shared among blocks**

    //Little struct to hold the x and y offset of a tile.
    //Used by the blueprint dictionary
    public struct Offset
    {
        public Offset(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public int x, y;
    }

    public enum Direction { Right, Left, Down }
    public enum Shape { Line, Cube, Stair, Cross, Serpent, Gun, Ufo, Abort }

    //Blueprint dictionary that contains the informations to place tiles in a block
    //Shape is the type of block, and the list holds the tiles positions.
    public static Dictionary<Shape, List<Offset>> Blueprints = FileLoader.LoadBlocks();

    //Instance informations
    //List of tiles hold by the single block
    private List<Tile> tiles = new List<Tile>();
    //Shape of the block
    public Shape shape;

    public Block(Shape _shape)
    {
        shape = _shape;
    }

    
    public void AddTile(Tile tile)
    {
        tiles.Add(tile);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void Move(Direction dir)
    {
        foreach (Tile t in tiles)
        {
            t.Move(dir);
        }
    }

    void MoveRight()
    {
        Move(Direction.Right);
    }
    void MoveLeft()
    {
        Move(Direction.Left);
    }
    void MoveDown()
    {
        Move(Direction.Down);
    }
}

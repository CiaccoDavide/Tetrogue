using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour
{
    //Just a struct to hold x and y
    public struct Coords
    {
        public Coords(short _x, short _y)
        {
            x = _x;
            y = _y;
        }
        public short x, y;
    }

    public readonly static short Size = 4;
    public enum Direction { Right, Left, Down }
    public enum Shape { Line, Cube, Stair, Gun, Ufo, TotalNumber }

    //Blueprint dictionary that contains the informations to place tiles in a block.
    //Shape is the type of block, List<Coords> is the list of the offset of the tiles inside the block.
    //Everything is loaded from file
    public static Dictionary<Shape, Coords[]> Blueprints = FileLoader.LoadBlocks();

   
    private Tile[] tiles = new Tile[4];   //List of tiles inside the block

    public Shape shape;         //Shape of the block

    private Coords coords;      //Position (in field coordinates)

    private short margin;

    //"Constructor"
    public static Block Create()
    {
        GameObject block_go;
        block_go = Instantiate(Resources.Load("Prefabs/Block")) as GameObject;
        block_go.name = "Block";
        Block block_scr = block_go.GetComponent<Block>();
        return block_scr;
    }

    //Reset the block to the top and creates new tiles.
    //TODO -> Use a pool instead of dynamic instantiation
    public void ResetBlock()
    {
        Tile temp_tile;
        //Create the tiles and position them
        Shape random_shape = (Shape)Random.Range(0, (int)Shape.TotalNumber);
        for (int i =0; i < 4; i++)
        {
            Coords off = Blueprints[random_shape][i];
            temp_tile = Tile.Create();
            temp_tile.SetPosition(off.x, off.y);
            temp_tile.SetGround(Ground.grounds[0]);
            temp_tile.gameObject.transform.parent = transform;
            tiles[i] = temp_tile;
        }
        Roll();
        PushLeft();
        PushDown();
        CalculateMargin();
        //Set the position at the top of the field in a random position.
        //Need a few optimization if the block is not 
        SetPosition((short)Random.Range(0,Field.Width-Block.Size+margin+1),(short)12);
        InvokeRepeating("MoveDown", 1, 1);
    }

    private void PushLeft(){
        short min=4;
        for(short i=0; i<4;i++) 
            if(tiles[i].x<min) min=tiles[i].x;
        for(short i=0; i<4;i++) 
            tiles[i].SetPosition((short)(tiles[i].x-min),tiles[i].y);
    }
    private void PushDown(){
        short min=4;
        for(short i=0; i<4;i++) 
            if(tiles[i].y<min) min=tiles[i].y;
        for(short i=0; i<4;i++) 
            tiles[i].SetPosition(tiles[i].x,(short)(tiles[i].y-min));
    }
    private void CalculateMargin(){
        short max=0;
        for(short i=0; i<4;i++) 
            if(tiles[i].x>max) max=tiles[i].x;
        margin=(short)(3-max);
    }
    private void Roll(){
        if(Random.Range(0,2)==0)
            for(short i=0; i<4;i++)
                tiles[i].SetPosition(tiles[i].x,(short)(4-tiles[i].y));
        if(Random.Range(0,2)==0)
            for(short i=0; i<4;i++)
                tiles[i].SetPosition((short)(4-tiles[i].x),tiles[i].y);
        if(Random.Range(0,2)==0)
            for(short i=0; i<4;i++)
                tiles[i].SetPosition(tiles[i].y,tiles[i].x);

    }

    //Set the position of the block.
    //The tiles move with it cause they are children
    private void SetPosition(short x, short y)
    {
        coords.x = x;
        coords.y = y;
        float conversion = Tile.TileSize * 1.0f / Global.PixelToUnit;
        transform.position = new Vector3(((int)x - Field.Width / 2) * conversion, ((int)y - Field.Height / 2) * conversion, 0);
    }

    public void MoveRight()
    {
        if(coords.x<Field.Width-Block.Size+margin)
            SetPosition((short)(coords.x + 1), coords.y);
    }
    public void MoveLeft()
    {
        if(coords.x>0)
            SetPosition((short)(coords.x - 1), coords.y);
    }
    public void MoveDown()
    {
       SetPosition(coords.x, (short)(coords.y - 1));
    }
}

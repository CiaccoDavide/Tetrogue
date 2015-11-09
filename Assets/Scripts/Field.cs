using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {

    //the field holds a single block
    private Block block; 

    //Size of the field
    public readonly static int Width = 8;
    public readonly static int Height = 12;
   
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
        field_scr.block.ResetBlock();
        return field_scr;
    }
    public void HandleInput(){
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            block.MoveLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            block.MoveRight();
        if (Input.GetKey(KeyCode.DownArrow))
            block.MoveDown();
    }
}

using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {

    //the field holds a single block
    Block block; 

    //Size of the field
    public static int FieldWidth = 8;
    public static int FieldHeight = 12;
   
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
}

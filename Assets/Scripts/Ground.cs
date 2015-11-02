using UnityEngine;
using System.Collections;

public class Ground
{
    //Sprite representing the ground
    public Sprite sprite;
    //Walking speed multiplier of the terrain
    public float speed;

    //Pass the texture path and the speed of the terrain
    public Ground(string _path, float _speed) {
        Texture2D temp_text = Resources.Load("Textures/Grounds/" + _path) as Texture2D;
        sprite = Sprite.Create(temp_text, new Rect(0, 0, 64,64), new Vector2(0, 0));
        speed = _speed;
    }
}

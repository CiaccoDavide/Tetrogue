using UnityEngine;
using System.Collections;

public class Ground
{
    //Sprite representing the terrain
    public Sprite sprite;
    //Walking speed multiplier of the terrain
    public float speed;

    //Pass the texture path and the speed of the terrain
    public Ground(string _path, float _speed) {
        Texture2D temp_text = Resources.Load("Textures/" + _path) as Texture2D;
        sprite = Sprite.Create(temp_text, new Rect(0, 0, temp_text.width, temp_text.height), new Vector2(0, 0));
        _speed = 1.0f;
    }

    public Ground() {

    }
  
}

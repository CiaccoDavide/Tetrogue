using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

static class FileLoader
{

    private static string grounds_path = "./Assets/Resources/Data/terrains.txt";
    private static string blocks_path = "./Assets/Resources/Data/blocks.txt";

    private static Dictionary<string, Block.Shape> name_enum = new Dictionary<string, Block.Shape>
        {
            {"line",Block.Shape.Line},
            {"cube",Block.Shape.Cube},
            {"stair",Block.Shape.Stair},
            {"cross",Block.Shape.Cross},
            {"serpent",Block.Shape.Serpent},
            {"gun",Block.Shape.Gun},
            {"ufo",Block.Shape.Ufo},
            {"abort",Block.Shape.Abort},
        };

    public static List<Ground> LoadGrounds()
    {
        Ground temp_ground;
        string temp_string;
        List<Ground> grounds = new List<Ground>();

        using (StreamReader r = new StreamReader(grounds_path))
        {
            while ((temp_string = r.ReadLine()) != null)
            {
                string[] substrings = temp_string.Split(',');
                temp_ground = new Ground(substrings[0], float.Parse(substrings[1]));
                grounds.Add(temp_ground);
            }
        }

        return grounds;
    }

    public static Dictionary<Block.Shape, List<Block.Coords>> LoadBlocks()
    {
        Block.Shape temp_shape;
        Dictionary<Block.Shape,List<Block.Coords>> temp_blueprints = new Dictionary<Block.Shape,List<Block.Coords>>();
        string temp_string;
  
        using (StreamReader r = new StreamReader(blocks_path))
        {
            while ((temp_string = r.ReadLine()) != null)
            {
                string[] substrings = temp_string.Split(',');
                temp_shape = name_enum[substrings[0]];
                temp_blueprints[temp_shape] = new List<Block.Coords>();
                for (int i = 1; i < substrings.Length; i++)
                {
                    string[] pos = substrings[i].Split('-');
                    //Create whole gameobject of the tile with prefab
                    temp_blueprints[temp_shape].Add(new Block.Coords(int.Parse(pos[0]), int.Parse(pos[1])));
                }
            }
        }
        return temp_blueprints;
    }
}

using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public class oTiles
{
    public List<oTile> Items;

    public oTiles()
    {
        Items = new List<oTile>();
    }

    public void Initialize()
    {
        CreateTiles();
    }

    private void CreateTiles()
    {
        try
        {
            StreamReader sr = new StreamReader("Assets/Resources/tiles.txt");
            string line;

           

            while(!sr.EndOfStream)
            {
                line = sr.ReadLine();
                Items.Add(new oTile(line));
            }
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

}


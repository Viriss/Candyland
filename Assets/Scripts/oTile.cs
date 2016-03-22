using UnityEngine;
using System;

public class oTile
{
    public TileColor Color;
    public Vector2 Center;
    public string Special;

    public oTile()
    {
        Color = TileColor.pink;
        Center = new Vector2(0, 0);
        Special = "";
    }
    public oTile(TileColor TileColor, Vector2 Center, string Special) : this()
    {
        this.Color = TileColor;
        this.Center = Center;
        this.Special = Special;
    }

    public oTile(string Data) : this()
    {
        try {
            string[] parts = Data.Split(',');
            float x;
            float y;

            this.Color = (TileColor)Enum.Parse(typeof(TileColor), parts[0]);
            x = float.Parse(parts[1]);
            y = float.Parse(parts[2]);
            this.Center = new Vector2(x, y);

            if (parts.Length == 4)
            {
                this.Special = parts[3];
            }

        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}

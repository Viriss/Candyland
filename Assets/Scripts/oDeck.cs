using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class oDeck {

    public List<oCard> Cards;
    public List<oCard> Discard;
    public oCard CurrentCard;

    public oDeck()
    {
        Cards = new List<oCard>();
    }

    public void Create()
    {
        AddFullColorToDeck(TileColor.red);
        AddFullColorToDeck(TileColor.blue);
        AddFullColorToDeck(TileColor.green);
        AddFullColorToDeck(TileColor.orange);
        AddFullColorToDeck(TileColor.purple);
        AddFullColorToDeck(TileColor.yellow);
    }

    public oCard DrawCard()
    {
        int i = Random.Range(0, Cards.Count);
        CurrentCard = Cards[i];
        Cards.Remove(CurrentCard);
        return CurrentCard;
    }

    private void AddFullColorToDeck(TileColor Color) {
        AddNumberOfCards(8, Color, 1);
        AddNumberOfCards(2, Color, 2);
    }
    private void AddNumberOfCards(int Number, TileColor Color, int Size)
    {
        for(int i = 0; i< Number; i++)
        {
            AddCardToDeck(Color, Size);
        }
    }
    private void AddCardToDeck(TileColor Color, int Size)
    {
        oCard c = new oCard();
        c.Color = Color;
        c.Number = Size;

        Cards.Add(c);
    }

}

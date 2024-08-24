using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private CardDB DeckDB;
    [SerializeField] private List<CardInfo> DeckCards;
    [SerializeField] private CardGenerator cardGenerator;
    private AudioSource SoundEffect;

    void Awake()
    {
        SoundEffect = this.GetComponent<AudioSource>();
        DeckCards = new List<CardInfo>(DeckDB.CardList);
        Shuffle();
    }

    public void Shuffle()
    {
        int n = DeckCards.Count() - 1;
        while (n >= 1)
        {
            int newPos = Random.Range(0, n);
            var temp = DeckCards[newPos];
            DeckCards[newPos] = DeckCards[n];
            DeckCards[n--] = temp;
        }
    }

    public Card Draw()
    {
        if (DeckCards.Count == 0) return null;

        SoundEffect.Play();
        var cardInfo = DeckCards.Last();
        DeckCards.RemoveAt(DeckCards.Count - 1);
        var drawnCard = cardGenerator.InstantiateCard(cardInfo);
        return drawnCard;
    }

    public void ReAddCards(params CardInfo[] cards)
    {
        foreach (var card in cards)
            if (card is not null) this.DeckCards.Add(card);

        Shuffle();
    }
}
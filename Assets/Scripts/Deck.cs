using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> player1Deck = new List<Card>(); // Mazo del jugador 1
    public List<Card> player2Deck = new List<Card>(); // Mazo del jugador 2

    private List<Card> player1Hand = new List<Card>();
    private List<Card> player2Hand = new List<Card>();


    // Clase de ejemplo para representar una carta
     [System.Serializable]
    public class Card
    {
        public GameObject cardprefab;
        public string name;
        public int strength;
        public string faction;
        public string ability;
        public string zone;
    }
        // Otros atributos de la carta (habilidades, facción, etc.)

       private void Start()
    {
        // Baraja los mazos primero
        ShuffleDeck(player1Deck);
        ShuffleDeck(player2Deck);

        // Reparte 10 cartas a cada jugador
        player1Hand.AddRange(player1Deck.GetRange(0, 10));
        player2Hand.AddRange(player2Deck.GetRange(0, 10));

        // Ahora player1Hand y player2Hand contienen las cartas iniciales
        // Puedes usarlas en la lógica de tu juego.
    }

    private void ShuffleDeck(List<Card> deck)
    {
        int n = deck.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1); // Genera un índice aleatorio
            // Intercambia los elementos en las posiciones i y j
            Card temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Card", menuName = "Card/Unit")]
public class UnitCardInfo : CardInfo
{
    public TipodeUnidad UnitType;
    public int Poder;
    public Ataque[] AttackTypes;
}

public enum TipodeUnidad { Plata, Oro }

public enum Ataque
{
    CuerpoACuerpo, Distancia, Asedio
}

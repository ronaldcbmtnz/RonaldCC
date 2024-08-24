using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Special")]
public class SpecialCardInfo : CardInfo
{
    public TipoEspecial SpecialType;  
    

}
public enum TipoEspecial
{
    Aumento, Clima1, Clima2, Clima3, Señuelo, Despeje
}


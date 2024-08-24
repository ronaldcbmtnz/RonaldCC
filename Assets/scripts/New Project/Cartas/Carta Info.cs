using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : ScriptableObject
{
    public string Faccion;
    public string Nombre;
    public Efecto Effect;
    public string Efecto => Effect.ToString();
    public Sprite Imagen;
    
}


public enum Efecto
{
    Robar, DestruirFilaMenor, DestruirCartaMenor, DestruirCartaMayor,
    MultiplicarPoder, BalancearPoder, Aumento, PonerClima, Versatil, Null, Señuelo
}

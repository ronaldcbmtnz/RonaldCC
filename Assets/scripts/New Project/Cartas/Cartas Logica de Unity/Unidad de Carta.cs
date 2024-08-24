using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public abstract class Unit : Card
{
    [SerializeField] Image Artwork;
    public UnitCardInfo card;
    public GameObject[] AttackTypeIcons;
    public TextMeshProUGUI PowerText;
    protected int power;
    public int Power => power;
    public override CardInfo CardInfo { get => card; }
    public override void SetCardInfo(CardInfo cardInfo)
    {
        this.card = cardInfo as UnitCardInfo;
    }

    void Start()
    {
         Artwork.sprite = card.Imagen;
        power = card.Poder;
        PowerText.text = power.ToString();
        AttackTypeIcons[0].SetActive((card.AttackTypes.Contains(Ataque.CuerpoACuerpo)));
        AttackTypeIcons[1].SetActive((card.AttackTypes.Contains(Ataque.Distancia)));
        AttackTypeIcons[2].SetActive((card.AttackTypes.Contains(Ataque.Asedio)));
    }
}
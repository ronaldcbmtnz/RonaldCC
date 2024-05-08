using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
     private Vector3 originalScale;
    public float enlargementFactor = 2.0f;
    public Vector2 desiredCornerPosition = new Vector2(-268, -2); // Cambia las coordenadas según tu diseño
    private bool isCursorOverCard = false;
    public GameObject enlargedCardUI; // Asigna el objeto UI de la carta agrandada en el Inspector

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(
            GetComponent<RectTransform>(), Input.mousePosition))
        {
            // El cursor está sobre la carta original
            isCursorOverCard = true;
            transform.localScale = originalScale * enlargementFactor;
        }
        else
        {
            // El cursor no está sobre la carta original
            isCursorOverCard = false;
            transform.localScale = originalScale;
        }

        // Muestra u oculta la carta agrandada según el estado del cursor
        enlargedCardUI.SetActive(isCursorOverCard);
        if (isCursorOverCard)
        {
            // Establece la posición de la esquina deseada para la carta agrandada
            enlargedCardUI.GetComponent<RectTransform>().anchoredPosition = desiredCornerPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCartas : MonoBehaviour
{
    private bool isDragging = false;

    void Start()
    {
        
    }

    public void StarDrag()
    {
        isDragging=true;
    }
    
    public void EndDrag()
    {
        isDragging=false;
    }
    void Update()
    {
        if (isDragging)
        {
            transform.position= new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}

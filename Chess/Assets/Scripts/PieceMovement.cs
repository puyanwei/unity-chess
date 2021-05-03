using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject piece;

    void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == piece.name) 
                {
                    return;
                }
                else
                {
                    transform.position = hit.transform.position;
                }
            }
        }


    }

}

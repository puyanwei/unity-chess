using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public GameObject piece;
    public GameObject square;
    private Vector3 movement;


    void Start()
    {
        movement = new Vector3(0, 0, 1);
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name != piece.name)
            {

                piece.transform.position = movement;
                movement += new Vector3(0,0,1);
                
            }
        }
    }

}

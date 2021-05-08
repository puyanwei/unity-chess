using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public GameObject piece;
    public GameObject square;
    public GameObject kill;
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    private Vector3 movement;

    private Vector3 allowedMovement = new Vector3(0, 0, 1);

    private bool isHovered = false;

    void Start()
    {
        movement = new Vector3(0, 0, 2);
        piece.transform.position = movement;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (isHovered)
        {
            ShowAllowedMovements(allowedMovement);
        }

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name != piece.name)
            {
                piece.transform.position = movement;
                movement += allowedMovement;
            }
        }        
    }   
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == kill.name)
        {
            GameObject.Destroy(piece);
        }
        
    }


    void OnMouseOver()
    {
        rend.material.color = hoverColor;
        isHovered = true;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        isHovered = false;
    }

    void ShowAllowedMovements(Vector3 position)
    {
        ray = Camera.main.ScreenPointToRay(piece.transform.position + position);
        Physics.Raycast(ray, out hit);
        Debug.Log("There's a chess block in front");
    }

}

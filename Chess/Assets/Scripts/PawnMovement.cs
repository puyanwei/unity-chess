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
    public GameObject kill;
    public GameObject shadow;
    public GameObject[] shadows;
    private Vector3 sMovement;

    void Start()
    {
        movement = new Vector3(0, 0, 2);
        


    }

    void Update()
    {
        shadows = GameObject.FindGameObjectsWithTag("shadow");


        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            sMovement = movement + new Vector3(0, 1, 0);


        if (shadows.Length == 0)
        {
            shadow.transform.position = sMovement;
            Debug.Log("No game objects are tagged with 'shadow'");
            Instantiate(shadow, sMovement, piece.transform.rotation);

        }
        foreach (GameObject shadow in shadows)
        {
            Destroy(shadow);
        }








            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name != piece.name)
                {

                    piece.transform.position = movement;
                    movement += new Vector3(0, 0, 1);
                    
                
                       

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

}

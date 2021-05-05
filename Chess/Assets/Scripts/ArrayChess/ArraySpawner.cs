using UnityEngine;
using System.Collections;

public class ArraySpawner : MonoBehaviour
{
    public Transform squarePrefab;
    public Transform spawnPoint;
    
    public float timeBetweenSpawns = 0.5f;
    private float countdown = 1.5f;  
    private int squareIndex = 0;
    public int cloneCount = 0;


    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnSquares());
            countdown = timeBetweenSpawns;
        }

        countdown -= Time.deltaTime;

        
    }

    IEnumerator SpawnSquares()
    {
        for (int i = 0; i < squareIndex;)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        squareIndex++;
    }

    void SpawnEnemy()
    {
        if (cloneCount <= 8)
        {
            Instantiate(squarePrefab, spawnPoint.position, spawnPoint.rotation);
            spawnPoint.position += new Vector3(1, 0, 0);
            cloneCount++;
        }
        else
        {
            return;
        }


    }

}













//if (i == depth.Length)
//{
//    return;
//}
//else
//{

//    for (i = 0; i < depth.Length; i++)
//    {
//        // Debug.Log(i);

//        {
//            Instantiate(square, startPosition, Quaternion.identity);
//            Debug.Log(i);


//            startPosition += new Vector3(0, 0, 1);
//            timeTobuild -= Time.deltaTime;

//        }

//    }

//}
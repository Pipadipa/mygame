using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkahuman : MonoBehaviour
{
    public GameObject[] humans;
    public static int csc;
    int buf;
    static public bool right; 
    
    void Start()
    {
        StartCoroutine(spawnHuman());
        buf = 0;
    }

    IEnumerator spawnHuman() 
    {
        while (true)
        {
            int scale = Random.Range(0, 5);
            if (scale >= buf)
            {
                Instantiate(humans[scale], new Vector3(3, Random.Range(-2, 5), 1), Quaternion.identity);
                right = true;
            }
            if (scale < buf)
            {
                Instantiate(humans[scale], new Vector3(-3, Random.Range(-2,5), 1), Quaternion.identity);
                right = false;
            }
            csc = scale;
            buf = scale;
            yield return new WaitForSeconds(3.0f);
        }
    }
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnabird : MonoBehaviour
{
    public GameObject[] birds;
    public static float cx, cy;
    int  num;
    float buf, rand;
    
    // Start is called before the first frame update

    private void Start()
    {
        buf = 0;
        int[] x = new int[2];
        int[] y = new int[7];
        x[0] = -4;
        x[1] = 4;
        for (int i = 0; i < 7; i++) y[i] = 6 - (i * 2);
        StartCoroutine(Sbird());

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) { StartCoroutine(Sbird()); }   
    }
    IEnumerator Sbird() 
    {
        while (true)
        {
            rand = Random.Range(0.0f, 10.0f);
            num = 0;
            if(rand <= 1.75f) 
            {
                num = 1;
                if (rand <= 0.75f) 
                {
                    num = 2;
                    if (rand <= 0.25f) num = 3;
                }
            }
            if (rand > buf)
            {
                cx = -18;
                cy = Random.Range(-6.0f, 6.0f);
                Instantiate(birds[num].gameObject, new Vector2(18, Random.Range(-6.0f, 6.0f)), Quaternion.identity);
            }
            if(rand < buf) 
            { 
                cx = 18;
                cy = Random.Range(-6.0f, 6.0f);
                Instantiate(birds[num].gameObject, new Vector2(-18, Random.Range(-6.0f, 6.0f)), Quaternion.identity);
            }
            buf = rand;
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}

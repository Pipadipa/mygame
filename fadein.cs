using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadein : MonoBehaviour
{
    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.position.x > 2.3f) gameObject.transform.position = new Vector2(2.3f, gameObject.transform.position.y);
        if (gameObject.transform.position.x < -2.3f) gameObject.transform.position = new Vector2(-2.3f, gameObject.transform.position.y);
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine("fade");
        Destroy(gameObject, 1.05f);
    }

    IEnumerator fade() 
    {
        for(float f = 1f; f>= -0.05f; f-= 0.05f) 
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public GameObject[] prefmeat;
   
    public Vector2 direction;
    public Animator an;
    float x, y;
    float speed;
    private void Start() 
    {
        if (gameObject.CompareTag("Pigeon"))
            speed = 0.07f;
        if (gameObject.CompareTag("Crow"))
            speed = 0.09f;
        if (gameObject.CompareTag("Duck"))
            speed = 0.011f;
        if (gameObject.CompareTag("Bluejay"))
            speed = 0.013f;
        x = spawnabird.cx;
        y = spawnabird.cy;
        if(x < 0) 
        {
            
            if (gameObject.CompareTag("Pigeon") || gameObject.CompareTag("Crow")) 
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            
        }
        if(x > 0) 
        {
            
            if (gameObject.CompareTag("Bluejay") || gameObject.CompareTag("Duck")) 
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
           
        }
        Debug.Log(x);
        Destroy(gameObject,5.0f);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,new Vector2(x, y), speed);
         
    }
   /* private void OnMouseDown()
    {
       
        
        if (gameObject.CompareTag("Pigeon")) 
        playerproperty.meat++;
        if (gameObject.CompareTag("Crow"))
            playerproperty.meat+=4;
        if (gameObject.CompareTag("Duck"))
            playerproperty.meat+=7;
        if (gameObject.CompareTag("Bluejay"))
            playerproperty.meat+=10;
        an.SetBool("life", false);
        speed = 0;
        Destroy(gameObject, 0.35f);
    }*/
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            an.SetBool("life", false);
            speed = 0;
            Destroy(collision.gameObject);
            if (gameObject.CompareTag("Pigeon"))
            {
                playerproperty.pmeat += RealXpSys.curup[0];
                Instantiate(prefmeat[0], gameObject.transform.position, Quaternion.identity);
            }
            if (gameObject.CompareTag("Crow"))
            {
                playerproperty.cmeat += RealXpSys.curup[1];
                if(RealXpSys.curup[1] != 0)
                Instantiate(prefmeat[1], gameObject.transform.position, Quaternion.identity);
            }
            if (gameObject.CompareTag("Duck"))
            {
                playerproperty.dmeat += RealXpSys.curup[2];
                if (RealXpSys.curup[2] != 0)
                    Instantiate(prefmeat[2], gameObject.transform.position, Quaternion.identity);
            }
            if (gameObject.CompareTag("Bluejay"))
            {
                playerproperty.bmeat += RealXpSys.curup[3];
                if (RealXpSys.curup[3] != 0)
                    Instantiate(prefmeat[3], gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject, 0.35f);
        }
    }
}

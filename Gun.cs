using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject gunner;
    public GameObject bullet;
    public Transform muzzle;
    public Slider sl;
    public float offset;
    bool right;
    bool debug;
    float buf1 , rotz , timer;
    // Start is called before the first frame update
    void Start()
    {
        right = true;
        debug = false;
        //buf2 = 91;
    }
     public void shoot() 
    {
        if (right)
        Instantiate(bullet, muzzle.position, transform.rotation);
        else Instantiate(bullet, muzzle.position, muzzle.transform.rotation);
    }

     
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) { shoot(); }
        if (timer <= 0) { shoot();  timer = 0.5f; }
        
        if (Input.GetKeyDown(KeyCode.D)) debug = false;
        /*Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        buf1 = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        if (buf1 > -25 || buf1 < -155)
             rotz = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;*/
        //Debug.Log(rotz);
        
        //if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0 && right )
        if(rotz > 90 && right )
        {
            gunner.transform.localScale = new Vector2(-gunner.transform.localScale.x, gunner.transform.localScale.y);
            right = false;
            offset = -180;

            buf1 = rotz;
            
        }
        //if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0 && right == false )
        if (rotz < 90 && !right && rotz > -26)
        {
            gunner.transform.localScale = new Vector2(-gunner.transform.localScale.x, gunner.transform.localScale.y);
            right = true;
            offset = 0;
            
            //debug = true;
        }
        
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
        timer -= Time.deltaTime;
    }
    public void OnSlider() 
    {
        rotz = sl.value;
        if(rotz > 180) 
        {
            rotz -= 360;
        }
    }
}

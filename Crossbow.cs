using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Crossbow : MonoBehaviour
{
    public GameObject gunner;
    public GameObject[] bullet;
    public Transform muzzle;
    public Text ammo;
    public float offset;
    bool right;
    bool debug;
    static public int index;
    float buf1, buf2;
    // Start is called before the first frame update
    void Start()
    {
        RedrawText(index);
        right = true;
        debug = false;
        buf2 = 91;
    }
    public void shoot(int index)
    {
        switch (index)
        {
            case 0:
                if (playerproperty.pkebab > 0)
                {
                    if (right)
                        Instantiate(bullet[index], muzzle.position, transform.rotation);
                    else Instantiate(bullet[index], muzzle.position, muzzle.transform.rotation);
                    playerproperty.pkebab--;
                    ammo.text = playerproperty.pkebab.ToString();
                }
                break;
            case 1:
                if (playerproperty.ckebab > 0)
                {
                    if (right)
                        Instantiate(bullet[index], muzzle.position, transform.rotation);
                    else Instantiate(bullet[index], muzzle.position, muzzle.transform.rotation);
                    playerproperty.ckebab--;
                    ammo.text = playerproperty.ckebab.ToString();
                }
                break;
            case 2:
                if (playerproperty.dkebab > 0)
                {
                    if (right)
                        Instantiate(bullet[index], muzzle.position, transform.rotation);
                    else Instantiate(bullet[index], muzzle.position, muzzle.transform.rotation);
                    playerproperty.dkebab--;
                    ammo.text = playerproperty.dkebab.ToString();
                }
                break;
            case 3:
                if (playerproperty.bkebab > 0)
                {
                    if (right)
                        Instantiate(bullet[index], muzzle.position, transform.rotation);
                    else Instantiate(bullet[index], muzzle.position, muzzle.transform.rotation);
                    playerproperty.bkebab--;
                    ammo.text = playerproperty.bkebab.ToString();
                }
                break;
        }
        
        
    }
    void Update()
    {
        if (!playerproperty.ui)
        {
            Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotz = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
            if (Input.GetMouseButtonDown(0)) shoot(index);
        }
    }
    void RedrawText(int ind) 
    {
        switch (ind)
        {
            case 0:
                if (playerproperty.pkebab > 0)
                {
                    ammo.text = playerproperty.pkebab.ToString();
                }
                break;
            case 1:
                if (playerproperty.ckebab > 0)
                { 
                    ammo.text = playerproperty.ckebab.ToString();
                }
                break;
            case 2:
                if (playerproperty.dkebab > 0)
                {
                    ammo.text = playerproperty.dkebab.ToString();
                }
                break;
            case 3:
                if (playerproperty.bkebab > 0)
                {
                    ammo.text = playerproperty.bkebab.ToString();
                }
                break;
        }
    }
}

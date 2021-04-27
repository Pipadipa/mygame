using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] GameObject[] skins;
    [SerializeField] GameObject muzzle;
    static public int curskin;
    void Start()
    {
        curskin = 0;
        skins[curskin].SetActive(true);
        switch (curskin) 
        {
            case 0:
                muzzle.transform.localPosition = new Vector2(1.06f, 0);
                break;
            case 1:
                muzzle.transform.localPosition = new Vector2(0.97f, 0.01f);
                break;
            case 2:
                muzzle.transform.localPosition = new Vector2(1.165f, 0.085f);
                break;
            case 3:
                muzzle.transform.localPosition = new Vector2(1.01f, -0.01f);
                break;

        }
        
    }

    void Update()
    {
        
    }
}

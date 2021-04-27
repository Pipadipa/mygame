using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPbar : MonoBehaviour
{
    private Text clvl;
    private Image barim;
    private levelsystem levelSystem;
    
    
    private void Awake()
    {
        clvl = transform.Find("textlvl").GetComponent<Text>();
        barim = transform.Find("progress").GetComponent<Image>();
       // Debug.Log("joopa");
    }
    public void SetExBarSize(float exNorm) 
    {
        barim.fillAmount = exNorm;
    }
    public void SetLvlNum(int levelNum) 
    {
        clvl.text = "Level " + (levelNum + 1);
    } 
   
}

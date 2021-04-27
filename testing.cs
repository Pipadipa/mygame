using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class testing : MonoBehaviour
{
    [SerializeField] private XPbar xpbar;
    private walking _walk;
    
    
    public void Awake()
    {
        levelsystem levelsys = new levelsystem();
        Debug.Log(levelsys.GetLevelNumber());
        levelsys.addxp(50);
        Debug.Log(levelsys.GetLevelNumber());
        levelsys.addxp(80);
        Debug.Log(levelsys.GetLevelNumber());
        
        LevelSystemAnime levelSystemAnime = new LevelSystemAnime(levelsys);
        
    }

    private void Singleton_expose(int xp)
    {
        Debug.Log("+10xp");
    }
}

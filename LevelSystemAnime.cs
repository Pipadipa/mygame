using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class LevelSystemAnime 
{
    private levelsystem lvlsys;
    private bool isanim;
    private int level;
    private int xp;
    
    public event EventHandler onexch;
    public event EventHandler onlvlch;
    private float updateTimer;
    private float updateTimerMax;
    

    public LevelSystemAnime(levelsystem lvlsys) 
    {
        SetLvlSys(lvlsys);
        FunctionUpdater.Create(() => Update());
    }
    public void SetLvlSys(levelsystem lvlsys) 
    {
        this.lvlsys = lvlsys;
        level = lvlsys.GetLevelNumber();
        xp = lvlsys.GetXp();
        
        lvlsys.onlvlch += Lvlsys_onlvlch;
        lvlsys.onexch += Lvlsys_onexch;
    }

    private void Lvlsys_onexch(object sender, System.EventArgs e)
    {
        isanim = true;
    }

    private void Lvlsys_onlvlch(object sender, System.EventArgs e)
    {
        isanim = true;
    }
    private void Update() 
    {
        if (isanim) 
        {
            updateTimer += Time.deltaTime;
            while (updateTimer > updateTimerMax)
            {
                updateTimer -= updateTimerMax;
                Updateaddxp();
            }
        }
        Debug.Log(level + " " + xp);
    }
    private void Updateaddxp() 
    {
        if (level < lvlsys.GetLevelNumber())
        {
            addxp();
        }
        else
        {
            if (xp < lvlsys.GetXp())
            {
                addxp();
            }
            else isanim = false;
        }
    }
    private void addxp() 
    {
            xp++;
            if (xp >= lvlsys.GetXpToNext(level))
            {
                level++;
                xp = 0;
                if (onlvlch != null) onexch(this, EventArgs.Empty);
            }
            if (onexch != null) onexch(this, EventArgs.Empty);
        
    }
    public int GetLevelNumber()
    {
        return level;
    }
    public int GetXp()
    {
        return xp;
    }
    public int GetXpToNext()
    {
        return lvlsys.GetXpToNext(level);
    }
   
    public float GetExperienceNormalized()
    {
        if (lvlsys.IsMaxLvl(level)) 
        {
            return 1.0f;
        }
        else 
        {
            return (float)xp / lvlsys.GetXpToNext(level);
        }
    }
}

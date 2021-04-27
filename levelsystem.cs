using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class levelsystem
{
    public event EventHandler onexch;
    public event EventHandler onlvlch;
    private int level;
    private int xp;
    private static readonly int[] xptolvl = new[] { 100, 120, 140, 160, 180, 200, 220, 240, 260, 280 };
    public levelsystem()
    {
        level = 0;
        xp = 0;
        
    }
    public void addxp(int amount) 
    {
        if (!IsMaxLvl())
        {
            xp += amount;
            while (!IsMaxLvl() && xp >= GetXpToNext(level))
            {
                level++;
                xp -= GetXpToNext(level);
                if (onlvlch != null) onexch(this, EventArgs.Empty);
            }
            if (onexch != null) onexch(this, EventArgs.Empty);
        }
    }
    public int GetLevelNumber() 
    {
        return level;
    }
    public int GetXp() 
    {
        return xp;
    }
    public int GetXpToNext(int level) 
    {
        if (level < xptolvl.Length)
        {
            return xptolvl[level];
        }
        else
        {
            return 100;
        }
    }
    public float GetExperienceNormalized() 
    {
        if (IsMaxLvl()) return 1.0f;
        else return (float)xp / GetXpToNext(level);
    }
    public bool IsMaxLvl()
    {
        return IsMaxLvl(level);
    }
    public bool IsMaxLvl(int level)
    {
        return level == xptolvl.Length - 1;
    }
}
    


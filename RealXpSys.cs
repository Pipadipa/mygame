using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealXpSys : MonoBehaviour
{
    [SerializeField] XPbar xpbar;
    static public int[] curup = new[] { 10 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,0 ,0  };
    static public readonly string[] names = new[] {" Мясо Голубя" ," Мясо Вороны" ," Мясо Утки" ," Мясо Сойки" ," Шаурма из Голубя" ," Шаурма из Вороны" ," Шаурма из Утки" ," Шаурма из Сойки" ," " ," "  };
    static public readonly string[] Descriptions = new[] { "Позволяет вам получать мясо за каждого голубя, повторное улучшение увеличит количество получаемого мяса", "Позволяет вам получать мясо за каждую ворону, повторное улучшение увеличит количество получаемого мяса", "Позволяет вам получать мясо за каждую утку, повторное улучшение увеличит количество получаемого мяса", "Позволяет вам получать мясо за каждую сойку, повторное улучшение увеличит количество получаемого мяса", " Позволяет вам готовить шаурму из голубя, при повторном улучшении увеличивает стомоисть", " Позволяет вам готовить шаурму из вороны, при повторном улучшении увеличивает стомоисть", " Позволяет вам готовить шаурму из утки, при повторном улучшении увеличивает стомоисть", " Позволяет вам готовить шаурму из сойки, при повторном улучшении увеличивает стомоисть", " ", " " };
    static public int Xp , spoint;
    static int realxp, clvl;
    private static int xptolvl = 100;
    private void Start()
    {
       /* Xp = 0;
        spoint = 0;
        clvl = 0;
        realxp = 0;*/
        xpbar.SetExBarSize(GetBarSize(realxp));
        xpbar.SetLvlNum(clvl);
    }
    void Update()
    {
        if (Xp > 0)
        {
            realxp += Xp;
            Xp = 0;
            if(realxp >= xptolvl) 
            {
                realxp -= xptolvl;
                clvl++;
                spoint++;
                xptolvl += 70; 
            }
            xpbar.SetExBarSize(GetBarSize(realxp));
            xpbar.SetLvlNum(clvl);
        }
    }
    float GetBarSize(int xp) 
    {
        return (float)xp / xptolvl;
    } 
}

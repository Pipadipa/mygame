using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealXpSys : MonoBehaviour
{
    [SerializeField] XPbar xpbar;
    static public int[] curup = new[] { 10 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,0 ,0  };
    static public readonly string[] names = new[] {" ���� ������" ," ���� ������" ," ���� ����" ," ���� �����" ," ������ �� ������" ," ������ �� ������" ," ������ �� ����" ," ������ �� �����" ," " ," "  };
    static public readonly string[] Descriptions = new[] { "��������� ��� �������� ���� �� ������� ������, ��������� ��������� �������� ���������� ����������� ����", "��������� ��� �������� ���� �� ������ ������, ��������� ��������� �������� ���������� ����������� ����", "��������� ��� �������� ���� �� ������ ����, ��������� ��������� �������� ���������� ����������� ����", "��������� ��� �������� ���� �� ������ �����, ��������� ��������� �������� ���������� ����������� ����", " ��������� ��� �������� ������ �� ������, ��� ��������� ��������� ����������� ���������", " ��������� ��� �������� ������ �� ������, ��� ��������� ��������� ����������� ���������", " ��������� ��� �������� ������ �� ����, ��� ��������� ��������� ����������� ���������", " ��������� ��� �������� ������ �� �����, ��� ��������� ��������� ����������� ���������", " ", " " };
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

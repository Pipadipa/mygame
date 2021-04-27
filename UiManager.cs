using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject Ui;
    [SerializeField] private GameObject OpenB;
    [SerializeField] private Text[] leveltxt;
    [SerializeField] private Text Name;
    [SerializeField] private Text Description;
    [SerializeField] private Text CurrentLvl;
    [SerializeField] private Image[] imar;
    [SerializeField] private GameObject changeScene;
    [SerializeField] private GameObject[] projectileList;
    [SerializeField] public Sprite[] kebabs;
    [SerializeField] public Image[] slots;
    [SerializeField] public Image mainSlot;
    [SerializeField] private GameObject shop;
    [SerializeField] GameObject shopb;

    Sprite bufs;
    int skillnum,curproj,buf;
    bool isopen;
    int[] projList = new int[3] {0 ,0 ,0 };
    
    void Start()
    {
        mainSlot.sprite = kebabs[0];
        
        curproj = 0;
        Crossbow.index = curproj;
        isopen = false;
        Ui.gameObject.SetActive(false);
        skillnum = 0;
        RedrawSkillWindow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseUi() 
    {
        Ui.gameObject.SetActive(false);
        OpenB.gameObject.SetActive(true);
        changeScene.SetActive(true);
        shopb.SetActive(true);
    }
    public void OpenUi()
    {
        shopb.SetActive(false);
        changeScene.SetActive(false);
        OpenB.gameObject.SetActive(false);
        Ui.gameObject.SetActive(true);
    }
    public void SetSkillMeatOne() 
    {
        skillnum = 0;
        RedrawSkillWindow();
    }
    public void SetSkillMeatTwo()
    {
        skillnum = 1;
        RedrawSkillWindow();
    }
    public void SetSkillMeatThree()
    {
        skillnum = 2;
        RedrawSkillWindow();
    }
    public void SetSkillMeatFour()
    {
        skillnum = 3;
        RedrawSkillWindow();
    }
    public void SetSkillKebabOne()
    {
        skillnum = 4;
        RedrawSkillWindow();
    }
    public void SetSkillKebabTwo()
    {
        skillnum = 5;
        RedrawSkillWindow();
    }
    public void SetSkillKebabThree()
    {
        skillnum = 6;
        RedrawSkillWindow();
    }
    public void SetSkillKebabFour()
    {
        skillnum = 7;
        RedrawSkillWindow();
    }
    public void Upgrade()
    {
        if(RealXpSys.spoint > 0) 
        {
            if (skillnum != 0 && skillnum != 4)
            {
                if (RealXpSys.curup[skillnum - 1] != 0)
                {
                    RealXpSys.spoint--;
                    RealXpSys.curup[skillnum]++;
                    RedrawSkillWindow();
                }
            }
            else
            {
                RealXpSys.spoint--;
                RealXpSys.curup[skillnum]++;
                RedrawSkillWindow();
            }
        }

    }
    public void RedrawSkillWindow() 
    {
        for(int i = 0; i < 8; i++)
        { 
            leveltxt[i].text = RealXpSys.curup[i].ToString();
            if (RealXpSys.curup[i] == 0) 
            {
                imar[i].color = new Color(0f, 0f, 0f);
            }
            else imar[i].color = new Color(100f, 50f, 50f);
        }
        Name.text = RealXpSys.names[skillnum];
        Description.text = RealXpSys.Descriptions[skillnum];
        CurrentLvl.text ="Текущий уровень: " + RealXpSys.curup[skillnum].ToString();
    }
    public void LoadShootBird() 
    {
        SceneManager.LoadScene("ShootBird");
    }
    public void LoadShawermathrow()
    {
        SceneManager.LoadScene("Shawermathrow");
    }
    public void OpenProjectilesList() 
    {
        if (!isopen)
        {
            for (int i = 0; i < 3; i++)
            {
                
                
                if (i >= curproj)
                {
                    if (RealXpSys.curup[5 + i] != 0)
                    {
                        projectileList[i].SetActive(true);
                        slots[i].sprite = kebabs[i + 1];
                        projList[i] = i + 1;
                    }
                }
                else 
                {
                    if (RealXpSys.curup[4 + i] != 0)
                    {
                        projectileList[i].SetActive(true);
                        slots[i].sprite = kebabs[i];
                        projList[i] = i;
                    }
                }
                    if (i == 2) isopen = true;
            }
        }
        else 
        {
            CloseDropDown();
        }
    }
    public void FirstSlotButton() 
    {
        ResetMainSlot(0);
        CloseDropDown();
    }
    public void SecondSlotButton()
    {
        ResetMainSlot(1);
        CloseDropDown();
    }
    public void ThirdSlotButton()
    {
        ResetMainSlot(2);
        CloseDropDown();
    }
    private void CloseDropDown() 
    {
        for (int i = 0; i < 3; i++)
        {
            projectileList[i].SetActive(false);
            if (i == 2) isopen = false;
        }
    }
    private void ResetMainSlot(int index) 
    {
        bufs = mainSlot.sprite;
        mainSlot.sprite = slots[index].sprite;
        slots[index].sprite = bufs;
        buf = projList[index];
        projList[index] = curproj;
        curproj = buf;
        Crossbow.index = curproj;
    }
    public void OpenShop() 
    {
        shop.SetActive(true);
        changeScene.SetActive(false);
        OpenB.gameObject.SetActive(false);
        shopb.SetActive(false);
        playerproperty.ui = true;
    }
    public void CloseShop()
    {

        shop.SetActive(false);
        changeScene.SetActive(true);
        OpenB.gameObject.SetActive(true);
        shopb.SetActive(true);
        playerproperty.ui = false;
    }
}

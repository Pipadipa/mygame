using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KebabMakyr : MonoBehaviour
{
    [SerializeField] public GameObject[] buttons;
    [SerializeField] public Sprite[] b;
    [SerializeField] public Sprite[] c;
    [SerializeField] public Image[] d;
    [SerializeField] public Slider sl;
    [SerializeField] public Image source1;
    [SerializeField] public Image source2;
    [SerializeField] public Text meat;
    [SerializeField] public Text kebab;
    [SerializeField] GameObject FurnaceUI;
    int index, industry;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 4; i < 8; i++) 
        {
            if(RealXpSys.curup[i] == 0)
            {
                buttons[i - 4].SetActive(false);
            }
        }
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (industry) 
        {
            case 1:
                if (playerproperty.pmeat > 0)
                {
                    if (timer >= 0.2)
                    {
                        playerproperty.pkebab++;
                        timer = 0f;
                        playerproperty.pmeat--;
                        kebab.text = playerproperty.pkebab.ToString();
                    }
                    timer += Time.deltaTime;
                    sl.value = timer / 0.2f;
                }
                meat.text = playerproperty.pmeat.ToString();
                break;
            case 2:
                if (playerproperty.cmeat > 0)
                {
                    if (timer >= 5)
                    {
                        playerproperty.ckebab++;
                        timer = 0f;
                        playerproperty.cmeat--;
                        kebab.text = playerproperty.ckebab.ToString();
                    }
                    timer += Time.deltaTime;
                    sl.value = timer / 5f;
                }
                meat.text = playerproperty.cmeat.ToString();
                break;
            case 3:
                if (playerproperty.dmeat > 0)
                {
                    if (timer >= 5)
                    {
                        playerproperty.dkebab++;
                        timer = 0f;
                        playerproperty.dmeat--;
                        kebab.text = playerproperty.dkebab.ToString();
                    }
                    timer += Time.deltaTime;
                    sl.value = timer / 5f;
                }
                meat.text = playerproperty.dmeat.ToString();
                break;
            case 4:
                if (playerproperty.bmeat > 0)
                {
                    if (timer >= 5)
                    {
                        playerproperty.bkebab++;
                        timer = 0f;
                        playerproperty.bmeat--;
                        kebab.text = playerproperty.bkebab.ToString();
                    }
                    timer += Time.deltaTime;
                    sl.value = timer / 5f;
                }
                meat.text = playerproperty.bmeat.ToString();
                break;
        }
       /* timer -= Time.deltaTime;
        sl.value = 5 - timer / 5f;*/
    }
    public void FirstB() 
    {
        index = 1;
        source1.sprite = b[index - 1];
        source2.sprite = c[index - 1];
        source1.transform.localScale = new Vector2(5, 5);
        source2.transform.localScale = new Vector2(5, 5);
        kebab.text = playerproperty.pkebab.ToString();
    }
    public void SecondB()
    {
        index = 2;
        source1.sprite = b[index - 1];
        source2.sprite = c[index - 1];
        source1.transform.localScale = new Vector2(5, 5);
        source2.transform.localScale = new Vector2(5, 5);
        kebab.text = playerproperty.ckebab.ToString();
    }
    public void ThirdB()
    {
        index = 3;
        source1.sprite = b[index - 1];
        source2.sprite = c[index - 1];
        source1.transform.localScale = new Vector2(5, 5);
        source2.transform.localScale = new Vector2(5, 5);
        kebab.text = playerproperty.dkebab.ToString();
    }
    public void FourthB()
    {
        index = 4;
        source1.sprite = b[index - 1];
        source2.sprite = c[index - 1];
        source1.transform.localScale = new Vector2(5, 5);
        source2.transform.localScale = new Vector2(5, 5);
        kebab.text = playerproperty.bkebab.ToString();
    }
    public void MakeButton() 
    {
        switch (index)
        {
            case 1:
                industry = 1;
                if (timer != 0) timer = 0;
                kebab.text = playerproperty.pkebab.ToString();
                break;
            case 2:
                industry = 2;
                if (timer != 0) timer = 0;
                kebab.text = playerproperty.ckebab.ToString();
                break;
            case 3:
                industry = 3;
                if (timer != 0) timer = 0;
                kebab.text = playerproperty.dkebab.ToString();
                break;
            case 4:
                industry = 4;
                if (timer != 0) timer = 0;
                kebab.text = playerproperty.bkebab.ToString();
                break;
        }
    }
    public void CloseUi() 
    {
        FurnaceUI.SetActive(false);
    }
    public void OpenUi() 
    {
        FurnaceUI.SetActive(true);
    }
}

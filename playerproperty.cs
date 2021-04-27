using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerproperty : MonoBehaviour
{
    public Text rscore;
    static public int rubles;
    public Text pscore;
    static public int pmeat;
    public Text cscore;
    static public int cmeat;
    public Text dscore;
    static public int dmeat;
    public Text bscore;
    static public int bmeat;
    static public int pkebab;
    static public int ckebab;
    static public int dkebab;
    static public int bkebab;
    static public bool ui;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        pscore.text = pmeat.ToString();
        cscore.text = cmeat.ToString();
        dscore.text = dmeat.ToString();
        bscore.text = bmeat.ToString();
        rscore.text = rubles.ToString();
    }
}

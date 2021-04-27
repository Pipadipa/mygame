using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseOne : MonoBehaviour
{
    // Start is called before the first frame update
    public Text description;
    public GameObject unlockButton;
    public GameObject buyButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Description desc = collision.gameObject.GetComponent("Description") as Description;
        description.text = desc.productName;
        if (desc.isUnlocked) 
        {
            unlockButton.SetActive(true);
            buyButton.SetActive(false);
        }
        else 
        {
            unlockButton.SetActive(false);
            buyButton.SetActive(true);
        }
        if(collision.gameObject.transform.localScale.x > 0) 
        { 
            collision.gameObject.transform.localScale = new Vector2(0.5f, 0.5f); 
        }
        else
            collision.gameObject.transform.localScale = new Vector2(-0.5f, 0.5f);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        description.text = "Выберете товар";
        unlockButton.SetActive(false);
        buyButton.SetActive(false);
        if (collision.gameObject.transform.localScale.x > 0)
        {
            collision.gameObject.transform.localScale = new Vector2(0.4f, 0.4f);
        }
        else
            collision.gameObject.transform.localScale = new Vector2(-0.4f, 0.4f);
    }
    
}

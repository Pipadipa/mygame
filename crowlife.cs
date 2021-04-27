using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowlife : MonoBehaviour
{
    public Vector2 direction;
    public Animator an;
    private void Start()
    {
        
    }
    private void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }
    private void OnMouseDown()
    {
        direction = new Vector2(0, 0);
        an.SetBool("life", false);
        Destroy(gameObject, 0.5f);
    }
}

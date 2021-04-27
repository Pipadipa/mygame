using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRayCast : MonoBehaviour
{
    public bool IsRayCast;
    void Start()
    {
        gameObject.GetComponent<UnityEngine.EventSystems.PhysicsRaycaster>().enabled = false;
    }
}

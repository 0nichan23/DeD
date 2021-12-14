using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnPlay : MonoBehaviour
{
    public bool on;
    public Mapgenerator map;
    void Start()
    {
        gameObject.SetActive(on);
        if (on)
        {
            map.DrawMapInEditor();

        }
    }

   
}

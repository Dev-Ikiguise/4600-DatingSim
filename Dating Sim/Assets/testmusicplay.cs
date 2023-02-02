using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmusicplay : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<SoundManager>().Play("Menu Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chika_dance_script : MonoBehaviour
{

    void Start()
    {
        FindObjectOfType<Sound_manager>().Play("chika_dance");
    }

 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActiveController : MonoBehaviour
{
    Button a;
    // Start is called before the first frame update
    void Start()
    {
        
        {
         a.gameObject.SetActive(false);
         a.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpImageChange : MonoBehaviour
{
    public GameObject Image;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Oncilck()
    {
        Image.SetActive(!Image.active);
    
        
    }
}

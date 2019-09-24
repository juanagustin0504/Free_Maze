using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    public void NewObject()
    {
        GameObject bush = Instantiate(Resources.Load("Prefabs/bush"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        bush.name = "bush"; 
    }
        
}
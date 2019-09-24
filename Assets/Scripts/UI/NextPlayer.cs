using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPlayer : MonoBehaviour
{

    public void NextPlayerNumberBtn()
    {
        PlayerCamera.pn++;
        if(PlayerCamera.pn >= SelectCharacterManager.GetInstance().GetPlayerCount()) {
            PlayerCamera.pn = 0;
        }
        

    }

}

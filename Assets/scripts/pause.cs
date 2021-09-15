using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    bool ispaused = false;

    public void pausegame()
    {
        if(ispaused)
        {
            Time.timeScale = 1;
            ispaused = false;

        }else
        {
            Time.timeScale = 0;
            ispaused = true;
        }
    }
}

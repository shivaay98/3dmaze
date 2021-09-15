using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudmanager : MonoBehaviour
{
    public float currenttime = 0f;
    public float startingtime = 300f;
    public float timeelaps = 0;
    public float finalpoints = 0;
    public float levelscore = 10.0f;

    [SerializeField] Text countdown;
    [SerializeField] Text timespent;
    [SerializeField] Text finalscore;
    private accelerator cond;
    private void Start()
    {
        currenttime = startingtime;
        cond = GameObject.Find("Sphere").GetComponent<accelerator>();
    }
 
    public void final()
    {
        finalpoints = (startingtime - timeelaps) * levelscore;
        finalscore.text = "Finalscore : "+finalpoints.ToString("000");
    }
    private void Update()
    {
        if (cond.winloose == false)
        {
            currenttime -= 1 * Time.deltaTime;
            countdown.text = "Timer : " + currenttime.ToString("000");

            if (currenttime <= 0)
            {
                currenttime = 0;
            }
        }
        timeelaps = startingtime - currenttime;
        timespent.text = "Timespent : "+(timeelaps).ToString("000");
        
    }
   
}

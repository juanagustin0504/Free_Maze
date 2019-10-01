using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text TimeText;
    public float time;
    public string timerStr;
    public int min;
    public int sec;
    void Start()
    {
        TimeText = GetComponent<Text>();
    }
    private void Update()
    {
        time -= Time.deltaTime;
        min = (int)time / 60;
        sec = (int)time % 60;
        timerStr = min.ToString("00") + " : " + sec.ToString("00");
        TimeText.text = timerStr;
           }
}

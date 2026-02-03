using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerValue = 0;
    public float maxTimer = 10;
    public Slider timerVisuals;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerVisuals.value = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timerValue += Time.deltaTime;
        timerVisuals.value = timerValue;

        if (timerValue > maxTimer)
        {
            timerValue = 0;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBarScriptSoapy : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    // set max HP
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.enabled = true;
    }

    // set HP sekarang
    public void SetHealth(int health)
    {
        slider.value = health;

        // kalau habis, disable fill image
        if (slider.value <= slider.minValue)
        {
            fill.enabled = false;
        }
        else
        {
            fill.enabled = true;
        }
    }
}
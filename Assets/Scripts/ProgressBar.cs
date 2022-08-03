using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    

    public void SetProgressBar(float max_val,  float curr_val, float min_value)
    {
        Slider slider = GetComponent<Slider>();
        slider.value = ((curr_val - min_value) / (max_val - min_value));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceBar : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI messages;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public int maxDistance;
    int distancePassed;

    void Start()
    {
        slider.maxValue = maxDistance;
        slider.value = 0;
        distancePassed = 0;
    }

    void Update()
    {
        messages.text = (maxDistance - distancePassed) + " meters left!";
    }
    public void SetDistance(int distance)
    {
        distancePassed = distancePassed + distance;
        slider.value = distancePassed;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

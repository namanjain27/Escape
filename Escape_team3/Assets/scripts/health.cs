using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public float maxHealth;

    public void Start()
    {
		slider = GetComponent<Slider>();
		SetMaxHealth(100f);
    }
    public void SetMaxHealth(float health)
	{
		maxHealth = health;
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetHealth(float health)
	{
		slider.value = health;
		ChangeColor(slider.value);
	}

	public void ChangeColor(float sliderValue)
	{
		if (sliderValue <= maxHealth && sliderValue >= 0.75 * maxHealth)
		{
			fill.color = gradient.Evaluate(1f);
		}
		else if (sliderValue < 0.75 * maxHealth && sliderValue >= 0.5 * maxHealth)
		{
			fill.color = gradient.Evaluate(0.8f);
		}
		else if (sliderValue < 0.5 * maxHealth && sliderValue >= 0.25 * maxHealth)
		{
			fill.color = gradient.Evaluate(0.5f);
		}
		else if (sliderValue < 0.25 * maxHealth && sliderValue >= 0)
		{
			fill.color = gradient.Evaluate(0.2f);
		}
	}
}

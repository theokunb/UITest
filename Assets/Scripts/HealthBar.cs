using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _displayValue;

    private Slider _bar;

    private void Start()
    {
        _bar = GetComponent<Slider>();
    }

    private void Update()
    {
        _displayValue.text = $"{_bar.value}/{_bar.maxValue}";
    }

    public void TakeDamage(float value)
    {
        _bar.value -= value;
    }

    public void TakeHealing(float value)
    {
        _bar.value += value;
    }
}

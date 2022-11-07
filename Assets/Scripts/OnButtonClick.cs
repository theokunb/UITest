using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClick : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private HealthBar _healthBar;

    private void OnValidate()
    {
        if(_value < 0)
        {
            _value = 0;
        }
    }

    public void TakeDamage()
    {
        _healthBar.TakeDamage(_value);
    }

    public void TakeHealing()
    {
        _healthBar.TakeHealing(_value);
    }
}

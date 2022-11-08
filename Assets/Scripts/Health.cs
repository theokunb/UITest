using System.Collections;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event Action HelathChanged;
    
    public float CurrentHealth { get; private set;}
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void AddValue(float value)
    {
        CurrentHealth += value;

        if(CurrentHealth > _maxHealth)
        {
            CurrentHealth = _maxHealth;
        }
        HelathChanged?.Invoke();
    }

    public void ReduceValue(float value)
    {
        CurrentHealth -= value;

        if(CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
        HelathChanged?.Invoke();
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private TMP_Text _displayValue;
    [SerializeField] private float _changeRate;

    private Slider _bar;

    private void OnEnable()
    {
        _playerHealth.HelathChanged += HealthChanged;
    }

    private void OnDisable()
    {
        _playerHealth.HelathChanged -= HealthChanged;
    }

    private void Start()
    {
        _bar = GetComponent<Slider>();
        _bar.maxValue = _playerHealth.MaxHealth;
        _bar.value = _playerHealth.CurrentHealth;
    }

    private void Update()
    {
        _displayValue.text = $"{_bar.value}/{_bar.maxValue}";
    }

    private void HealthChanged()
    {
        StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        while(_bar.value != _playerHealth.CurrentHealth)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, _playerHealth.CurrentHealth, _changeRate * Time.deltaTime);
            yield return null;
        }
    }
}
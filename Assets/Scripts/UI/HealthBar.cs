using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _fillSpeed = 5;

    private Slider _healthBarSlider;    
    private float _healthBarTargetValueSlider;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _healthBarSlider = GetComponent<Slider>();
        _healthBarSlider.maxValue = _maxHealth;
        _healthBarSlider.value = _healthBarSlider.maxValue;
        _healthBarTargetValueSlider = _healthBarSlider.value;
    }

    private void Update()
    {
        if (_healthBarSlider.value != _healthBarTargetValueSlider)
        {
            _healthBarSlider.value = Mathf.MoveTowards(_healthBarSlider.value, _healthBarTargetValueSlider, _fillSpeed*Time.deltaTime);
        }
    }

    public void Heal(float value)
    {
        ChangeHealth(value);
    }

    public void TakeDamage(float value)
    {
        ChangeHealth(-value);
    }

    private void ChangeHealth(float value)
    {
        _healthBarTargetValueSlider = Mathf.Clamp(_healthBarTargetValueSlider + value, 0, _maxHealth);
        StartHealthAnimation(_healthBarTargetValueSlider);
    }

    private void StartHealthAnimation(float targetValue)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(AnimateToValue(targetValue));
    }

    private IEnumerator AnimateToValue(float targetValue)
    {
        while (Mathf.Abs(_healthBarSlider.value - targetValue) > 0.01f)
        {
            _healthBarSlider.value = Mathf.MoveTowards(_healthBarSlider.value, targetValue, _fillSpeed * Time.deltaTime);
            yield return null;
        }

        _healthBarSlider.value = targetValue;
        _currentCoroutine = null;
    }
} 


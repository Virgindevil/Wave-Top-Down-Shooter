using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _fillSpeed = 5;

    private Slider _healthBar;    
    private float _healthBarTargetValue;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _healthBar.maxValue;
        _healthBarTargetValue = _healthBar.value;
    }

    private void Update()
    {
        if (_healthBar.value != _healthBarTargetValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _healthBarTargetValue, _fillSpeed*Time.deltaTime);
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
        _healthBarTargetValue = Mathf.Clamp(_healthBarTargetValue + value, 0, _maxHealth);
        StartHealthAnimation(_healthBarTargetValue);
    }

    private void StartHealthAnimation(float targetValue)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(AnimateToValue(targetValue));
    }

    private IEnumerator AnimateToValue(float targetValue)
    {
        while (Mathf.Abs(_healthBar.value - targetValue) > 0.01f)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, targetValue, _fillSpeed * Time.deltaTime);
            yield return null;
        }

        _healthBar.value = targetValue;
        _currentCoroutine = null;
    }
}

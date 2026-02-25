using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _fillSpeed = 5;

    private Slider _healthBar;
    private float _healthBarTargetValue;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
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
        _healthBarTargetValue += value;
    }

    public void GetDamage(float value)
    {
        _healthBarTargetValue -= value;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class HealthViewSliderSmoothly : HealthView
{
    [SerializeField] private float _deley;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public override void UpdateHealthView(float healthCount, float maxHealthCount)
    {
        StopCoroutine(SmoothHealthTransition(healthCount, maxHealthCount));
        StartCoroutine(SmoothHealthTransition(healthCount, maxHealthCount));
    }

    private IEnumerator SmoothHealthTransition(float healthCount, float maxHealCount)
    {
        float epsilon = 0.0001f;
        bool isHealthZero = healthCount == 0;

        if (isHealthZero)
            healthCount = epsilon;

        float targetVelue = healthCount / maxHealCount;

        float step = 0.001f;
        float stepsCount = Mathf.Abs(targetVelue - _slider.value) / step;

        var waitForSeconds = new WaitForSeconds(_deley);

        for (int i = 0; i <= stepsCount; i++)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetVelue, step);

            yield return waitForSeconds;
        }

        if (isHealthZero)
            _slider.value = 0;

        _slider.fillRect.gameObject.SetActive(healthCount - epsilon > 0);
    }
}

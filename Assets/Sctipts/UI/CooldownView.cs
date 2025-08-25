using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class CooldownView : MonoBehaviour
{
    [SerializeField] private Vamperism _vamperism;
    private Slider _slider;

    private Coroutine _timer;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _vamperism.PullOutStarted += StartTimer;
        _vamperism.CooldownStarted += StartTimer;
    }

    private void OnDisable()
    {
        _vamperism.PullOutStarted -= StartTimer;
        _vamperism.CooldownStarted -= StartTimer;
    }

    private void StartTimer(float duration)
    {
        if (_timer != null)
            StopCoroutine(_timer);

        _timer = StartCoroutine(Timer(duration));
    }

    private IEnumerator Timer(float duration)
    {
        float time = 0;
        bool isSliderFilled = _slider.value >= 0.999;

        float startVelue = isSliderFilled ? 1 : 0;
        float endVelue = isSliderFilled ? 0 : 1;
        
        while (time < duration)
        {
            time += Time.deltaTime;

            _slider.value = Mathf.MoveTowards(startVelue, endVelue, time / duration);

            yield return null;  
        }
    }
}

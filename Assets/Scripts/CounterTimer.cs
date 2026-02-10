using System;
using System.Collections;
using UnityEngine;

public class CounterTimer : MonoBehaviour
{
    public event Action<int> OnValueChanged;

    private int _value; 
    private bool _isRunning = false; 
    private Coroutine _counterCoroutine;  
    [SerializeField] private float _interval = 0.5f; 
    public void Toggle()
    {
        if (_isRunning)
            StopCounting();
        else
            StartCounting();
    }

    private void StartCounting()
    {
        if (_counterCoroutine != null) return;
        _counterCoroutine = StartCoroutine(CountRoutine());
        _isRunning = true;
    }

    private void StopCounting()
    {
        if (_counterCoroutine != null)
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;
        }
        _isRunning = false;
    }

    private IEnumerator CountRoutine()
    {
        while (true)
        {
            _value++;
            OnValueChanged?.Invoke(_value);
            yield return new WaitForSeconds(_interval);
        }
    }
}

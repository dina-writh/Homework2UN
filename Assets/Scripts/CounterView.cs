using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private CounterTimer _counter; 

    private void OnEnable()
    {
        _counter.OnValueChanged += UpdateView;
    }

    private void OnDisable()
    {
        _counter.OnValueChanged -= UpdateView;
    }

    private void UpdateView(int value)
    {
        if (_counterText != null)
        {
            _counterText.text = value.ToString();
        }
        Debug.Log("Counter: " + value);
    }
}
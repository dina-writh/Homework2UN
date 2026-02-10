using UnityEngine;

public class InputReaderTimer : MonoBehaviour
{
    [SerializeField] private CounterTimer _counter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counter.Toggle();
        }
    }
}
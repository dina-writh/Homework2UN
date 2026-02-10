using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;

    private int _counter = 0;
    private bool _isRunning = false;
    private Coroutine _countCorutine;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_isRunning)
            {
                StopCoroutine(_countCorutine);
                _isRunning = false;
            }
            else
            {
                _countCorutine = StartCoroutine(IncrementCounter());
                _isRunning = true;
            }
        }       
    }

    private IEnumerator IncrementCounter()
    {
        while (true)
        {
            _counter++;
            Debug.Log("Counter: " + _counter);

            if (_counterText != null)
            {
                _counterText.text = _counter.ToString(); 
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UI))]
public class Timer : MonoBehaviour
{
    private int _time;
    private bool _isGoing = false;
    private UI _ui;

    private void Awake()
    {
        _ui = GetComponent<UI>();
    }

    public void SwapActivity()
    {
        if (_isGoing)
            StopTimer();
        else
            StartTimer();
    }

    private void StopTimer()
    {
        _isGoing = false;
        StopAllCoroutines();
    }

    private void StartTimer()
    {
        _isGoing = true;
        StartCoroutine(IncreaseTime());
    }

    private IEnumerator IncreaseTime()
    {
        yield return new WaitForSeconds(1);
        ++_time;
        _ui.UpdateText(_time.ToString());
        StartCoroutine(IncreaseTime());
    }
}

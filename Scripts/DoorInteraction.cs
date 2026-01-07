using System;
using System.Collections;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public bool isOpen = false;

    private Quaternion _closedRotation;
    private Quaternion _openRotation;
    private Coroutine _currentCoroutine; // Renamed the duplicate variable


    void Start() // Corrected capitalization from 'start' to 'Start'
    {
        _closedRotation = transform.rotation;
        // Corrected 'oulerAngles' to 'eulerAngles'
        _openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0)); 
    }


    void Update() // Corrected capitalization from 'Void' to 'void'
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Removed erroneous method call 'StepCoroutine' and check for null
            if (_currentCoroutine != null) StopCoroutine(_currentCoroutine); 
            _currentCoroutine = StartCoroutine(ToggleDoor());
        }
    }

    private IEnumerator ToggleDoor()
    {
        Quaternion targetRotation = isOpen ? _closedRotation : _openRotation;
        isOpen = !isOpen;

        // Corrected 'While' to 'while' and loop condition
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f) 
        {
            // Corrected Quaternion.Lerp arguments and added Time.deltaTime calculation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}

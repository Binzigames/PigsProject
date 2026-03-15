using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] private TargetTag _targetTag;
    [SerializeField] private UnityEvent OnTargetEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GetTargetTag()))
        {
            OnTargetEnter.Invoke();
        } 
    }
    private string GetTargetTag()
    {
        return _targetTag switch
        {
            TargetTag.Player => "Player",
            TargetTag.Road => "Road",
            _ => throw new NotImplementedException(),
        };
    }
}
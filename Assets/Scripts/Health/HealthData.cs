using System;
using UnityEngine.Events;

[Serializable]
public struct HealthData
{
    public int MaxHealth;
    public int CurrentHealth;
    public UnityEvent OnEndedHealth;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    public float currentValue;
    private float baseValue = 0;
    private List<float> modifiers = new List<float>();

    public float GetBaseValue()
    {
        return baseValue;
    }
    public float GetCurrentValue()
    {
        float finalValue = currentValue;
        modifiers.ForEach(x => finalValue += baseValue);
        return finalValue;
    }
    public void SetValue(float newValue)
    {
        currentValue = newValue;
    }
    public void AddModifier(float modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }
    public void RemoveModifier(float modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }
}

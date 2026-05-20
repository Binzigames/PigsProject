using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    [SerializeField]
    private bool _firstBoot;

    public bool FirstBoot
    {
        get => _firstBoot;
        set => _firstBoot = value;
    }
}

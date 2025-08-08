using System;
using UnityEngine;

public class EndOfDungeon : MonoBehaviour
{
    public Action OnEnterEndOfDungeon;

    void OnTriggerEnter(Collider other)
    {
        OnEnterEndOfDungeon?.Invoke();
    }
}

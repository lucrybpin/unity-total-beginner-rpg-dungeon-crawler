using System;
using UnityEngine;

public class EndOfDungeon : MonoBehaviour
{
    public GameObject canvas;

    public Action OnEnterEndOfDungeon;

    void OnTriggerEnter(Collider other)
    {
        OnEnterEndOfDungeon?.Invoke();
    }

}

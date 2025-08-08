using System;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    public Action OnSwordFound;

    void OnMouseDown()
    {
        OnSwordFound?.Invoke();
    }
}

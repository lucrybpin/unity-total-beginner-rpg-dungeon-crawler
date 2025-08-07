using System;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    public Action OnSwordFound;

    void OnMouseDown()
    {
        Debug.Log($">>>> Sword found");
        OnSwordFound?.Invoke();
    }
}

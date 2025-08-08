using System;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public Action OnTriggerEnterCutscene;
    void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterCutscene?.Invoke();
    }
}

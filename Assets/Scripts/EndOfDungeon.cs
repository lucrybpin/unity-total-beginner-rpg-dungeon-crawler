using UnityEngine;

public class EndOfDungeon : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($">>>> {other.name} entered End of Dungeon");
    }
}

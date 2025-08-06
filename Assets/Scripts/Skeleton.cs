using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int HP;

    public void Initialize(int initialHP)
    {
        HP = initialHP;
    }

    public void ReceiveDamage(int amount)
    {
        if (amount < HP)
        {
            // Hurt
            HP -= amount;
        }
        else
        {
            // Die
            HP = 0;
        }
    }
}

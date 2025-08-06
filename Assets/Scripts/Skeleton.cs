using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int HP;
    public Animator animator;
    public BoxCollider collider;

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
            animator.SetTrigger("Hit");
        }
        else
        {
            // Die
            HP = 0;
            animator.SetTrigger("Die");
            collider.enabled = false;
        }
    }
}

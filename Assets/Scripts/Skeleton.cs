using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int HP;
    public Animator animator;
    public BoxCollider boxCollider;
    public Vector3 offset;

    public float attackDelay = 4f;
    public float attackTimer = 0f;

    public void Initialize(int initialHP)
    {
        HP = initialHP;
    }

    public void Attack()
    {
        attackTimer += Time.deltaTime;

        Debug.DrawRay(transform.position + offset, transform.forward * 4f, Color.green, 2f);
        if (Physics.Raycast(transform.position + offset, transform.forward, out RaycastHit hit, 4.1f))
        {
            if (attackTimer > attackDelay)
            {
                attackTimer = 0f;
                animator.SetTrigger("Attack");
            }
        }
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
            boxCollider.enabled = false;
        }
    }
}

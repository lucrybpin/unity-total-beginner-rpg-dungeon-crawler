using System;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public int HP;
    public bool HaveSword = false;
    public GameObject SwordView;
    public Animator swordAnimator;
    public bool isMoving = false;

    public float attackDelay = 1f;
    public float attackTimer = 1f;

    public Action OnPlayerDie;

    public void Initialize(int initialHP)
    {
        HP = initialHP;
    }

    public void Move()
    {
        if (isMoving)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 4.1f))
            {
                isMoving = true;
                transform
                    .DOLocalMove(transform.position + 4 * transform.forward, 0.37f)
                    .OnComplete(() => isMoving = false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!Physics.Raycast(transform.position, -transform.forward, out RaycastHit hit, 4.1f))
            {
                isMoving = true;
                transform
                    .DOLocalMove(transform.position - 4 * transform.forward, 0.37f)
                    .OnComplete(() => isMoving = false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            isMoving = true;
            transform
                    .DOLocalRotate(transform.rotation.eulerAngles + new Vector3(0, -90f, 0), 0.37f)
                    .OnComplete(() => isMoving = false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            isMoving = true;
            transform
                    .DOLocalRotate(transform.rotation.eulerAngles + new Vector3(0, 90f, 0), 0.37f)
                    .OnComplete(() => isMoving = false);
        }
    }

    public void Attack()
    {
        if (!HaveSword)
            return;

        attackTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (attackTimer > attackDelay)
            {
                attackTimer = 0f;
                swordAnimator.SetTrigger("Attack");
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 4.1f))
                {
                    if (hit.transform.gameObject.TryGetComponent<Skeleton>(out Skeleton skeleton))
                    {
                        skeleton.ReceiveDamage(10);
                    }
                }
            }
        }
    }

    public void EquipSword()
    {
        HaveSword = true;
        SwordView.SetActive(true);
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
            OnPlayerDie?.Invoke();
        }
    }
}

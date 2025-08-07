using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int HP;
    public bool HaveSword = false;
    public GameObject SwordView;

    public Action OnPlayerDie;

    public void Initialize(int initialHP)
    {
        HP = initialHP;
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 4.1f))
            {
                transform.position += 4 * transform.forward;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!Physics.Raycast(transform.position, -transform.forward, out RaycastHit hit, 4.1f))
            {
                transform.position -= 4 * transform.forward;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation *= Quaternion.Euler(0f, -90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation *= Quaternion.Euler(0f, 90f, 0f);
        }
    }

    public void Attack()
    {
        if (!HaveSword)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 4.1f))
            {
                if (hit.transform.gameObject.TryGetComponent<Skeleton>(out Skeleton skeleton))
                {
                    skeleton.ReceiveDamage(10);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 3;
    public Collider2D swordCollider;

    Vector2 rightAttackOffset;


    private void Start()
    {

        rightAttackOffset = transform.position;
    }


    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    public void AttackLeft()
    {
        Debug.Log(rightAttackOffset);
        swordCollider.enabled = true;
        Debug.Log("wali w lewo");
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponentInChildren<Enemy>();
            Debug.Log(enemy);
            if (enemy != null)
            {
                enemy.Health -= damage;
            }
        }
    }
}

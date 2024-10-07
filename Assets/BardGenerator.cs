using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardGenerator : MonoBehaviour
{
    public GameObject projectilePrefab;  // UŒ‚‚ÌƒvƒŒƒnƒui’e‚È‚Çj
    public Transform attackPoint;        // UŒ‚‚ğ”­Ë‚·‚éˆÊ’u
    public float attackRate = 2f;        // UŒ‚‚ÌŠÔŠui•bj

    private float nextAttackTime = 0f;

    void Update()
    {
        // Œ»İ‚ÌŠÔ‚ªŸ‚ÌUŒ‚ŠÔ‚ğ‰ß‚¬‚Ä‚¢‚ê‚ÎUŒ‚‚·‚é
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        // UŒ‚‚ğ”­Ë‚·‚é
        if (projectilePrefab != null && attackPoint != null)
        {
            Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Mover
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage();
        }

        gameObject.SetActive(false);
    }
}

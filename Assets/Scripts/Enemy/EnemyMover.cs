using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : Mover
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Boundary _))
        {
            gameObject.SetActive(false);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField]
    private string[] _collisionTags;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var tag in _collisionTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Destroy(gameObject);
            }
        }
    }
}

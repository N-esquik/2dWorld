using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Apple apple))
        {
            Destroy(apple.gameObject);
        }
    }
}
using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement player))
        {
            Destroy(gameObject);
        }
    }
}

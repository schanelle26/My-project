// Collectible.cs
// When the player touches this, it adds to the score and destroys the object

using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectItem();
            Destroy(gameObject); // Remove collectible
        }
    }
}

// Collectible.cs
// When the player touches this, it adds to the score and destroys the object

using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that touched this has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Tell the GameManager to increase the score
            GameManager.instance.CollectItem();

            // Destroy this collectible object
            Destroy(gameObject);
        }
    }
}

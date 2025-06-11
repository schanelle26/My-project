// Collectible.cs - Adds to score and destroys object
using UnityEngine;


public class Collectible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectItem();
            Destroy(gameObject);
        }
    }
}


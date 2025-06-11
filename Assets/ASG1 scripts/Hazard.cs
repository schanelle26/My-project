// Hazard.cs
// Kills the player on contact and restarts the level

using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched hazard!");
            GameManager.instance.PlayerDied();
        }
    }
}

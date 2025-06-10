using UnityEngine;

public class playerBehaviourScript : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform spawnPoint;


bool canInteract =false;

//CoinBehaviour currentCoin;
 void OnInteract()
    { 
        if(canInteract)

        { 
            Debug.Log("Interact with Object");
            //currentCoin.CollectCoin();
        }
    
    }

    // Update is called once per frame
    void onTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "enter the trigger");
        if(other.gameObject.CompareTag("Collectible"))

        {
            Debug.Log("Collectible object detected");
            canInteract = true;
            //currentCoin = other.gameObject.Getcomponent<CoinBehaviour>();

        }
    }


    void OnFire()
    {
        Debug.Log("fire");
        GameObject newProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);






    }
}
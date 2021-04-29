
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // si ce qui est entré en collision avec l'ennemi possède le tag player
        {
            Destroy(objectToDestroy); // on détruit tout l'ennemi
        }
    }

    
}

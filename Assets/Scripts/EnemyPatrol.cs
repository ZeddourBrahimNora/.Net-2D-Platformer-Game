
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints; // les pts vers lesquels l'ennemi va se déplacer
    
    public SpriteRenderer graphics; // système de flip
    private Transform target; // le pts que l'ennemi doit atteindre target change chaque fois
    private int destPoint = 0; // destination

    public int damageOnCollision = 20 ; // degat infligé au moment de la collision


    void Start()
    {
        target = waypoints[0]; // initizliser le waypoint a 0 car c'est le début
    }


    void Update()
    {
        // direction dans laquelle on dirige l'ennemi
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); 

        // si la distance entre l'objet actuelle et le waypoint vers lequel l'ennemi se dirige est inférieur à x -> on passe au pts suivant
        // si l'ennemi est quasiment arrivé à sa destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX; // on ft l'inverse
        }

    }


    //detecter si le joueur entre en collision avec l'ennemi 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) // si l'ennemi rentre en contact avec le player
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>(); //
            playerHealth.TakeDamage(damageOnCollision); //Le personnage prends des dégats
        }
    }
}

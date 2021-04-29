using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // nbr de pts de vie du player par défaut
    public int currentHealth; // nbr de pts de vie actuelle

    public bool isInvincible = false; // au début du jeu le personnage n'est pas invincible

    public HealthBar healthBar;

    public SpriteRenderer graphics; // graphics -> le perso
    public float invicibilityFlashDelay = 0.2f; // délai du clignotement qu'on peut choisir sur unity
    public float invincibilityTimeAfterHit = 3f; //le temps d'invicibilité du personnage variable pr utiliser ds unity
    
    // le début
    void Start()
    {
        currentHealth = maxHealth; // il commence avec 100/100 de pts de vie
        healthBar.SetMaxHealth(maxHealth); // on set la health bar au max on la met à jour avec la methode dans healthbar
    }

    // temporaire : pour tester le système avec la touche H
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    // coroutine = methode qui permet de faire des "pauses" dans le code faire une action pause faire une autre action 

   public  void TakeDamage(int damage)
    {
        if (!isInvincible) 
        {
            currentHealth -= damage; // on prends les pts de vie actuelle et on leur retire les dégats
            healthBar.SetHealth(currentHealth); // mettre à jour le visuel de la healthbar avec les pts de vie actuelle
           
            isInvincible = true; // vue qu'il a prit des dégats il devient invincible
            StartCoroutine(InvincibilityFlash()); // on appelle la coroutine 
            StartCoroutine(HandleInvincibilityDelay());
        }
        
    }

    // faire briller le personnage lorsqu'il prends des dégats et le rendre "invincible" qlq instants
    // utilisation d'un système avec un filtre de couleurs qui changent de manière rapide

    public IEnumerator InvincibilityFlash()
    {
        while(isInvincible) // tant que le player est invincible 
        {
            graphics.color = new Color(1f, 1f, 1f, 0f); // on envoie les valeurs en rgb sous forme de valeurs entre 0 et 1 : ici c'est alpha -> transparence
            yield return new WaitForSeconds(invicibilityFlashDelay); //  mettre "pause"
            graphics.color = new Color(1f, 1f, 1f, 1f); // 
            yield return new WaitForSeconds(invicibilityFlashDelay); // mettre pause
        }
    }

    // système de timer pour arreter l'invincibilité du player
     
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit); // on attend un certain temps 
        isInvincible = false; // on enleve l'invincibilité au player
    }
}

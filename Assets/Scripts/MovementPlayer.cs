
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{

    // création du déplacement du player avec la méthode utilisant la physique -> rigidbody 2d le player sera affecté par la gravité

    public float moveSpeed; // vitesse de déplacement
    public float jumpForce;

    public Rigidbody2D rb; // fait réference au rigidbody du player
    private Vector3 velocity = Vector3.zero;
     
    private bool isJumping = false;  // false pcq qd le jeu démarre le player ne saute pas
    private bool isGrounded; 

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Animator animator;
    public SpriteRenderer spriteRenderer; // component ou se situe le flip
    
    private float horizontalMovement;

    void Update()
    {

        // savoir si le joueur a dmd a effectuer un saut

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x); // tjr renvoyer une valeur positif pcq si on va vers la gauche -> ce sera négatif -> illogique
        animator.SetFloat("Speed", characterVelocity);


    }

    void FixedUpdate()
    {
        // calculer la vitesse à laquelle le player va se déplacer
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;


        // va créer une zone entre le 1er élément et et le 2ème elmt comme un box collider 

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        MovePlayer(horizontalMovement);
    }

    // envoyer le mouvement au rigidbody pour pouvoir le déplacer

    void MovePlayer(float _horizontalMovement) // convention de nommage
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false; // -> pour dire qu'on a arreter de sauter
        }
    }

    // retourner le personnage quand il va en arrière
    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f) 
        {
            spriteRenderer.flipX = true;
        }
    }

}

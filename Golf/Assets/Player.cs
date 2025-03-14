using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse du joueur
    public float jumpForce = 5f; // Force de saut
    private Rigidbody rb;
    public float hitForce = 10f; // Force pour frapper la balle
    private Rigidbody ballRb;

    public Transform cameraTransform; // La cam�ra qui suit le joueur

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject ball = GameObject.Find("GolfBall"); // Assure-toi que la sph�re s'appelle "GolfBall"
        if (ball != null)
        {
            ballRb = ball.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(0)) // Clique gauche pour frapper
        {
            HitBall();
        }
    }

    void MovePlayer()
    {
        // R�cup�rer les entr�es de mouvement (ZQSD)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculer la direction du mouvement relative � la cam�ra
        Vector3 moveDirection = cameraTransform.forward * verticalInput + cameraTransform.right * horizontalInput;
        moveDirection.y = 0f; // On ignore la composante Y pour ne pas affecter la hauteur du joueur

        // Appliquer le mouvement au joueur
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void HitBall()
    {
        if (ballRb != null)
        {
            // Calculer la direction pour frapper la balle
            Vector3 direction = (ballRb.transform.position - transform.position).normalized;
            ballRb.AddForce(direction * hitForce, ForceMode.Impulse);
        }
    }
}

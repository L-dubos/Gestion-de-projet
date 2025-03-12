using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MovementMode { PingPong, Loop, OneWay }

    [Header("Points de déplacement")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    [Header("Paramètres de déplacement")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private bool reverse = false;
    [SerializeField] private MovementMode mode = MovementMode.PingPong;

    [Header("Activation par collision")]
    [SerializeField] private bool moveOnCollision = false;
    [SerializeField] private string requiredTag = "";

    private Vector3 target;
    private bool movingToEnd = true;
    private bool shouldMove = true;

    void Start()
    {
        if (startPoint == null || endPoint == null)
        {
            Debug.LogError($"[{name}] Assigne les points de départ et d'arrivée !");
            enabled = false;
            return;
        }

        transform.position = reverse ? endPoint.position : startPoint.position;
        target = reverse ? startPoint.position : endPoint.position;
    }

    void Update()
    {
        if (shouldMove)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            switch (mode)
            {
                case MovementMode.PingPong:
                    movingToEnd = !movingToEnd;
                    target = movingToEnd ? endPoint.position : startPoint.position;
                    break;

                case MovementMode.Loop:
                    transform.position = startPoint.position;
                    target = endPoint.position;
                    break;

                case MovementMode.OneWay:
                    enabled = false;
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!moveOnCollision) return;

        if (string.IsNullOrEmpty(requiredTag) || collision.gameObject.CompareTag(requiredTag))
        {
            shouldMove = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!moveOnCollision) return;

        if (string.IsNullOrEmpty(requiredTag) || collision.gameObject.CompareTag(requiredTag))
        {
            shouldMove = false;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private float direction = 0f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpforce = 10f;


    private Rigidbody2D rb;

    [Header("Ground Check")] [SerializeField]
    private Transform transformGroundCheck;

    [SerializeField] private LayerMask layerGround;

    [Header("Manager")] [SerializeField] private CoinManager coinManager;
    [SerializeField] private UIManager uiManager;

    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        canMove = true;
    }


    void Update()
    {
        if (canMove)
        {
            direction = 0;


            if (Keyboard.current.aKey.isPressed)
            {
                direction = -1;
            }

            if (Keyboard.current.dKey.isPressed)
            {
                direction = 1;
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }

            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
    }

    void Jump()
    {
        if (Physics2D.OverlapCircle(transformGroundCheck.position, 0.3f, layerGround))
        {
            rb.linearVelocity = new Vector2(0, jumpforce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("We entered a Trigger:" + other.name);

        if (other.CompareTag("coin"))
        {
            coinManager.AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("obstacle"))
        {
            uiManager.ShowPanelLost();
            canMove = false;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject LostPanel;
    [SerializeField] GameObject WinPanel;
    
    private float direction = 0f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpforce = 10f;

    private Animator anim;

    private Rigidbody2D rb;

    [Header("Ground Check")] [SerializeField]
    private Transform transformGroundCheck;

    [SerializeField] private LayerMask layerGround;

    [Header("Manager")] [SerializeField] private CoinManager coinManager;
    [SerializeField] private UIManager uiManager;
    
    [Header("Audio")]
    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource CoinSound;
    [SerializeField] private AudioSource DeadSound;
    [SerializeField] private AudioSource WinSound;
    
    

    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    public void Update()
    {
        canMove = !MenuPanel.activeSelf && StartPanel.activeSelf && !LostPanel.activeSelf || StartPanel.activeSelf && !LostPanel.activeSelf;
        if (canMove)
        {
            direction = 0;


            if (Keyboard.current.aKey.isPressed)
            {
                direction = -1;
                anim.SetTrigger("Run");
            }

            if (Keyboard.current.dKey.isPressed)
            {
                direction = 1;
                anim.SetTrigger("Run");
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
                JumpSound.Play();
            }

            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
    }

    void Jump()
    {
        if (Physics2D.OverlapCircle(transformGroundCheck.position, 0.3f, layerGround))
        {
            rb.linearVelocity = new Vector2(0, jumpforce);
            anim.SetTrigger("Jump");
        }
    }
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("We entered a Trigger:" + other.name);

        if (other.CompareTag("coin"))
        {
            coinManager.AddCoin();
            Destroy(other.gameObject);
            CoinSound.Play();
        }
        
        if (other.CompareTag("diamond"))
        {
            coinManager.AddDiamond();
            Destroy(other.gameObject);
            CoinSound.Play();
        }
        
        else if (other.CompareTag("obstacle"))
        {
            uiManager.ShowLostPanel();
            canMove = false;
            DeadSound.Play();
        }
        
        else if (other.CompareTag("goal"))
        {
            uiManager.ShowWinPanel();
            canMove = false;
            WinSound.Play();
        }
    }
}

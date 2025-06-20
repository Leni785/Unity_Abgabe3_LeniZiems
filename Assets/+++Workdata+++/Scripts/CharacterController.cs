using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{ //Hierdurch kann ich die Panels im Inspector zuordnen und die Panels über den Charactercontroller beeinflussen
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject StartPanel;
//Hierdurch kann ich die Panels im Inspector zuordnen und die Panels über den Charactercontroller beeinflussen
    [SerializeField] GameObject LostPanel;
    [SerializeField] GameObject WinPanel;
    
//Die Richtung des Characters wird hierdurch festgelegt (das "f" bewirkt, dass der Wert 0 als float und nicht als integer interpretiert wird)
    private float direction = 0f;

//Die Geschwindigkeit des Characters wird auf 2 festgelegt
    [SerializeField] private float speed = 2f;

// Die Sprungkraft des Characters wird auf 10 festgelegt
    [SerializeField] private float jumpforce = 10f;

//Der CharacterController kann auf den Animator zugreifen
    private Animator anim;

//Der CharacterController kann auf seinen Körper zugreifen und ihn beeinflussen
    private Rigidbody2D rb;

//Der Groundcheck wird deklariert und der CharacterController kann auf ihn zugreifen
    [Header("Ground Check")] [SerializeField]
    private Transform transformGroundCheck;

//Die Layer des Bodens wird deklariert und der CharacterController kann auf ihn zugreifen
    [SerializeField] private LayerMask layerGround;

//Der Charactercontroller kann auf den CoinManager und den UIManager zugreifen
    [Header("Manager")] [SerializeField] private CoinManager coinManager;
    [SerializeField] private UIManager uiManager;
    
//Der Charactercontroller kann auf die Sounds zugreifen
    [Header("Audio")]
    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource CoinSound;
    [SerializeField] private AudioSource DeadSound;
    [SerializeField] private AudioSource WinSound;
    
 // Das Bool(ein Datentyp der nur zwei Werte annehmen kann) canMove wird deklariert und aktiviert
    private bool canMove = true;

//Die Startfunktion wird einmalig automatisch ausgeführt
    void Start()
    {
//Der Körper und der Animator des Charactercontrollers werden aktiv
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

//Die Funktion Update() wird einmal pro Frame ausgeführt
   void Update()
    {
//Das Bool canMove kann nur ausgeführt werden, wenn das MenuPanel, das LostPanel und das WinPanel inaktiv und das StartPanel aktiv sind
        canMove = !MenuPanel.activeSelf && !LostPanel.activeSelf && !WinPanel.activeSelf && StartPanel.activeSelf ;

//Wenn die Funktion canMove ausgeführt wird,...
        if (canMove)
        {
//...beträgt die Richtung 0
            direction = 0f;

//...wird, wenn die A-Taste gedrückt wird,...
            if (Keyboard.current.aKey.isPressed)
            {//...die Richtung in die negative Richtung (nach links) geändert (-1) und die Animation "Run" wird ausgeführt
                direction = -1;
                anim.SetTrigger("Run");
            }
//...wird, wenn die D-Taste gedrückt wird,...
            if (Keyboard.current.dKey.isPressed)
            {//...die Richtung in die positive Richtung (nach rechts) geändert (1) und die Animation "Run" wird ausgeführt
                direction = 1;
                anim.SetTrigger("Run");
            }

//...wird, wenn die Space-Taste gedrückt wird,...
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {//...die Funktion "Jump()" ausgeführt und der Sound "JumpSound" wird abgespielt
                Jump();
                JumpSound.Play();
            }
//Der Character kann nach rechts und links bewegt werden und dabei springen, also kann der Spieler nach oben, links und rechts springen
//und auch wärend des Sprungs noch die Richtung beeinflussen 
            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
    }

//Die Funktion Jump wird deklariert
    void Jump()
    {//Wenn das Groundcheck Object (mit Radius 0.3f) auf dem Layer "Ground" mit einem Collider in Kontakt kommt...
        if (Physics2D.OverlapCircle(transformGroundCheck.position, 0.3f, layerGround))
        {//...kann sich nicht horizontal, aber vertikal (mit dem jumpforce-Wert) bewegt werden und die Animation "Jump" wird ausgeführt
            rb.linearVelocity = new Vector2(0, jumpforce);
            anim.SetTrigger("Jump");
        }
    }
    
    
//Diese Funktion wird ausgeführt, wenn ein (2D)Objekt mit einem Trigger-Collider mit dem Character, der einen Collider besitzt, kollidiert.
    private void OnTriggerEnter2D(Collider2D other)
    {//Der Debug.Log zeigt die Message "We entered a Trigger:" zusammen mit dem Namen des anderen Objekts
        Debug.Log("We entered a Trigger:" + other.name);
     //Wenn der Tag des anderen Objekts "coin" heißt...
        if (other.CompareTag("coin"))
        {//...wird die Funktion AddCoin() im coinManager ausgeführt
            coinManager.AddCoin();
         //...wird das andere Objekt zerstört
            Destroy(other.gameObject);
         //...wird der Sound "CoinSound" abgespielt
            CoinSound.Play();
        }

     //Wenn der Tag des anderen Objekts "diamond" heißt...
        else if (other.CompareTag("diamond"))
        {//...wird die Funktion AddDiamond() im coinManager ausgeführt
            coinManager.AddDiamond();
         //...wird das andere Objekt zerstört
            Destroy(other.gameObject);
         //...wird der Sound "CoinSound" abgespielt
            CoinSound.Play();
        }
        
     //Wenn der Tag des anderen Objekts "obstacle" heißt...
        else if (other.CompareTag("obstacle"))
        {//...wird im UIManger die Funktion ShowLostPanel() ausgeführt
            uiManager.ShowLostPanel();
        //...wird der Sound "DeadSound" abgespielt
            DeadSound.Play();
        }

     //Wenn der Tag des anderen Objekts "goal" heißt...
        else if (other.CompareTag("goal"))
        {//...wird im UIManger die Funktion ShowWinPanel() ausgeführt
            uiManager.ShowWinPanel();
        //...wird der Sound "WinSound" abgespielt
            WinSound.Play();
        }
    }
}

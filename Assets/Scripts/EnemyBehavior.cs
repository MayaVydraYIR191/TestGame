using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int positionOfPatrol;
    public Transform point;
    bool moveingRight;
    Transform player;
    public float stoppingDistance;
    [SerializeField] private int speed;

    [SerializeField]
    private float moveInput;

    [SerializeField] private bool facingRight;

    bool chill;
    bool angry;
    bool goBack;


    [SerializeField] private int enemyHealth;
    [SerializeField] private GameObject win;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth = 5;
    }

    private void Update()
    {
        if (enemyHealth == 0)
        {
            gameObject.SetActive(false);
            GameParameters.Instance.isWin = true;
            win.SetActive(true);
        }
        else if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if (chill)
        {
            Chill();
        }
        else if (angry)
        {
            Angry();
        }
        else if (goBack)
        {
            Goback();
        }
        
        moveInput = Player.moveInput;
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }


    
    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }


    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void Goback()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemyHealth -= 1;
        }
    }
}

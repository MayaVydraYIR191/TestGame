using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;
    public static float moveInput;
    private float moveUnpit;

    private Rigidbody2D rb;
    private bool facingRight = true;
    [SerializeField] private int playerHealth;
    [SerializeField] private Image bar;
    [SerializeField]private float fill;
    [SerializeField] private TMP_Text count;
    [SerializeField] private TMP_Text finalCount;
    [SerializeField] private GameObject lost;
    public static bool lose;

    
    private void Start()
    {
        lose = false;
        GameParameters.Instance.CoinOut();
        fill = 1f;
        playerHealth = 10;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        count.text = GameParameters.Instance.CoinCount.ToString();
        if (playerHealth == 0)
        {
            lose = true;
            gameObject.SetActive(false);
            lost.SetActive(true);
        }

        if (GameParameters.Instance.isWin)
        {
            finalCount.text = GameParameters.Instance.CoinCount.ToString();
        }
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        moveUnpit = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveInput * speed, moveUnpit*speed);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHealth -= 1;
            fill -= 0.1f;
            bar.fillAmount = fill;

        }

        else if (other.CompareTag("Coin"))
        {
            GameParameters.Instance.CollectCoin();
            Destroy(other.gameObject);
        }
    }
}

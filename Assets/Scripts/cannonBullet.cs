using UnityEngine;

public class cannonBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        lifeTime = lifeTime - Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}


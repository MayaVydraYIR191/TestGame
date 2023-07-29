using System.Collections;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject coin;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn ()
    {
        while (!Player.lose && !GameParameters.Instance.isWin)
        {
            Instantiate(coin, new Vector2(Random.Range(-7.21f, 7.80f), Random.Range(-3.4f,3.4f)), Quaternion.identity);
            yield return new WaitForSeconds(0.8f);
        }
    }

}

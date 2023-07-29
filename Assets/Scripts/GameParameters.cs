using GameKit.Managers;
public class GameParameters : SharedManager<GameParameters>
{
    public int CoinCount { get; private set; }
    public bool isWin;

    public void CollectCoin()
    {
        CoinCount++;
    }

    public void CoinOut()
    {
        CoinCount = 0;
    }

}


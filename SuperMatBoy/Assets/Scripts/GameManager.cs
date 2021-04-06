public class GameManager
{
    // public enum GameState { MENU, GAME, PAUSE, ENDGAME };

    // public GameState gameState { get; private set; }
    public int lifes;
    private int startingLifes = 4;
    public float timeElapsed;
    private float initialTime = 0.0f;
    public int flagsCaptured;
    private int startingFlags = 0;
    public bool bossTime;
    private static GameManager _instance;
    public bool levelPassed;
    public bool died;
    public bool win;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
    private GameManager()
    {
        lifes = startingLifes;
        timeElapsed = initialTime;
        levelPassed = false;
        died = false;
        flagsCaptured = startingFlags;
        bossTime = false;
        win = false;
    }

    public void Reset()
    {
        lifes = startingLifes;
        timeElapsed = initialTime;
        levelPassed = false;
        died = false;
        flagsCaptured = startingFlags;
        bossTime = false;
        win = false;
    }
}
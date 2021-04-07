using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Referencias:
// https://www.grimoirehex.com/unity-3d-local-leaderboard/
// https://www.youtube.com/watch?v=6GI9zzWsVm8&feature=emb_logo
public class PlayerInfo
{
    public string name;
    public float time;
    public PlayerInfo(string name, float time)
    {
        this.name = name;
        this.time = time;
    }
}
public class UI_LeaderBoard : MonoBehaviour
{
    public TMP_InputField playerName;
    public TMP_Text displaynames;
    public TMP_Text displaypts;
    public TMP_Text displaypos;
    GameManager gm;

    //Lista que vai guardar as stats do jogador
    List<PlayerInfo> collectedStats;

    // Start is called before the first frame update
    void Start()
    {
        collectedStats = new List<PlayerInfo>();
        gm = GameManager.GetInstance();
        displaynames.text = "";
        displaypts.text = "";
        displaypos.text = "";
        LoadLeaderBoard();

    }
    public void SubmitButton()
    {
        
        if(playerName.text.Length > 0 && playerName.text.Length <= 6){
            PlayerInfo stats = new PlayerInfo(playerName.text, gm.timeElapsed);
            collectedStats.Add(stats);
            playerName.text = "";
            SortStats();
        }
    }

    void SortStats()
    {
        for (int i = collectedStats.Count - 1; i > 0; i--)
        {
            if (collectedStats[i].time > collectedStats[i - 1].time)
            {
                PlayerInfo tempInfo = collectedStats[i - 1];

                collectedStats[i - 1] = collectedStats[i];
                collectedStats[i] = tempInfo;
            }
        }
        UpdatePlayerPrefsString();
    }

    void UpdatePlayerPrefsString()
    {
        string stats = "";
        for (int i = 0; i < collectedStats.Count; i++)
        {
            stats += collectedStats[i].name + ",";
            stats += collectedStats[i].time + ",";
        }

        //salva a string
        PlayerPrefs.SetString("SMBLeaderBoards", stats);

        UpdateLeaderBoardVisual();
    }

    void UpdateLeaderBoardVisual()
    {
        displaynames.text = "";
        displaypts.text = "";
        displaypos.text = "";

        for (int i = 0; i <= collectedStats.Count - 1; i++)
        {
            displaypos.text += (i + 1)+ "\n";
            displaynames.text += collectedStats[i].name+ "\n";
            displaypts.text += collectedStats[i].time + "\n";
        }
    }

    void LoadLeaderBoard()
    {
        string stats = PlayerPrefs.GetString("SMBLeaderBoards", "");
        string[] stats2 = stats.Split(',');

        for (int i = 0; i < stats2.Length - 2; i += 2)
        {
            PlayerInfo loadedInfo = new PlayerInfo(stats2[i], float.Parse(stats2[i + 1]));
            collectedStats.Add(loadedInfo);
            UpdateLeaderBoardVisual();
        }
    }

    public void ClearPrefs()
    {
        PlayerPrefs.DeleteKey("LeaderBoards");
        displaynames.text = "";
        displaypts.text = "";
        displaypos.text = "";
        Start();
    }
}

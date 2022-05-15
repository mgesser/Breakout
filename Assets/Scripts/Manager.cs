using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{
    public string playerName;
    public string highScorePlayer;
    public int highScore;
    public static Manager Instance;
    

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.savedHighScore = highScore;
        data.savedHighScorePlayer = highScorePlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.savedHighScore;
            highScorePlayer = data.savedHighScorePlayer;
        }
    }

    class SaveData
    {
        public int savedHighScore;
        public string savedHighScorePlayer;
    }

}

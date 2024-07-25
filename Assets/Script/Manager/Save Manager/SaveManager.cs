using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    //What we want to save
    [Header("Level Unlocked")]
    public bool level2Unlocked;
    public bool level3Unlocked;

    [Header("Initial Screen Setup")]
    public bool isFirstTime = true;
    //public int coin;
    //public int key;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            //coin = data.coin;
            //key = data.key;
            level2Unlocked = data.level2Unlocked;
            level3Unlocked = data.level3Unlocked;
            isFirstTime = data.isFirstTime;

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        //data.coin = coin;
        //data.key = key;
        data.isFirstTime = isFirstTime;
        data.level2Unlocked = level2Unlocked;
        data.level3Unlocked = level3Unlocked;

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class PlayerData_Storage
{
    public bool level2Unlocked;
    public bool level3Unlocked;
    public bool isFirstTime;
    //public int coin;
    //public int key;
}
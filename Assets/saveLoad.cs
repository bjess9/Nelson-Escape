using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class saveLoad : MonoBehaviour
{

    public void Save()
    {
        BinaryFormatter lcBinaryFormatter = new BinaryFormatter();
        FileStream lcSaveFile = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        GameModel lcSaveData = new GameModel();
        lcSaveData = GameManager.GameManagerInstance.GameModelInstance;
        lcBinaryFormatter.Serialize(lcSaveFile, lcSaveData);
        lcSaveFile.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter lcBinaryFormatter = new BinaryFormatter();
            FileStream lcLoadFile = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            GameModel saveData = (GameModel)lcBinaryFormatter.Deserialize(lcLoadFile);
            lcLoadFile.Close();

            GameManager.GameManagerInstance.GameModelInstance = saveData;
            
            //GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.LstInventory = saveData..LstInventory;
            //GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.CurrentArea = saveData.CurrentArea;
            //GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.Name = saveData.Name;
            //
        }
    }


    //void Awake()
    //{
    //    if (control == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        control = this;
    //    }
    //    else if (control != this)
    //    {
    //        Destroy(gameObject);
    //    }

    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonUtillDemo : MonoBehaviour
{
    const string saveFileName = "jsonUtillFile.sav";

    [SerializeField]
    private string name = "이승혁";
    [SerializeField]
    private int level = 99;

    [System.NonSerialized]
    public int age = 100;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private void Save()
    {
        print("Save To : " + getFilePath(saveFileName));

        string jsonString = JsonUtility.ToJson(this);
        StreamWriter sw = new StreamWriter(getFilePath(saveFileName));
        sw.Write(jsonString);
        sw.Close();
    }

    private void Load()
    {
        print("Load From : " + getFilePath(saveFileName));

    }

    private string getFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}

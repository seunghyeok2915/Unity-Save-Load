using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StreamDemo : MonoBehaviour
{
    const string saveFileName = "streamFile.sav";

    private string name = "이승혁";
    private int level = 99;

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

        StreamWriter sw = new StreamWriter(getFilePath(saveFileName));
        sw.WriteLine(name);
        sw.WriteLine(level);

        sw.Close();
    }

    private void Load()
    {
        print("Load From : " + getFilePath(saveFileName));

        StreamReader sr = new StreamReader(getFilePath(saveFileName));
        print(sr.ReadLine());
        print(sr.ReadLine());
    }

    private string getFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}

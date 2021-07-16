using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinaryFormatterDemo : MonoBehaviour
{
    const string saveFileName = "binaryFormatterFile.sav";

    private string name = "이승혁";
    private int level = 99;
    [System.Serializable]
    private class DataContainer
    {
        public string _name;
        public int _level;

        public DataContainer(string name, int level)
        {
            _name = name;
            _level = level;
        }
    }

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

        DataContainer dc = new DataContainer(name, level);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(getFilePath(saveFileName), FileMode.OpenOrCreate);

        bf.Serialize(fs, dc);

        fs.Close();
    }

    private void Load()
    {
        print("Load From : " + getFilePath(saveFileName));

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(getFilePath(saveFileName), FileMode.Open);

        DataContainer dc = bf.Deserialize(fs) as DataContainer;

        print(dc._name);
        print(dc._level);

        fs.Close();
    }

    private string getFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}

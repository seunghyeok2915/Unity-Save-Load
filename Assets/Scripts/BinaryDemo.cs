using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BinaryDemo : MonoBehaviour
{
    const string saveFileName = "binaryFile.sav";

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

        FileStream fs = new FileStream(getFilePath(saveFileName), FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(name);
        bw.Write(level);

        fs.Close();
        bw.Close();

    }

    private void Load()
    {
        print("Load From : " + getFilePath(saveFileName));

        FileStream fs = new FileStream(getFilePath(saveFileName), FileMode.Open);
        BinaryReader br = new BinaryReader(fs);

        print(br.ReadString());
        print(br.ReadInt32());

        fs.Close();
        br.Close();
    }

    private string getFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}

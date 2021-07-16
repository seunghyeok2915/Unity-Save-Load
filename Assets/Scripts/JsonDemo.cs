using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.IO;

public class JsonDemo : MonoBehaviour
{
    const string saveFileName = "jsonFile.sav";

    private string name = "이승혁";
    private int level = 99;

    public string[] friends;

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

        JObject jObj = new JObject();
        jObj.Add("ComponentName", GetType().ToString());

        JObject jDataObject = new JObject();
        jObj.Add("data", jDataObject);

        jDataObject.Add("name", name);
        jDataObject.Add("level", level);

        JArray jFirendsArray = JArray.FromObject(friends);
        jDataObject.Add("friends", jFirendsArray);

        StreamWriter sw = new StreamWriter(getFilePath(saveFileName));
        sw.WriteLine(jObj.ToString());

        sw.Close();
    }

    private void Load()
    {
        print("Load From : " + getFilePath(saveFileName));
        StreamReader sr = new StreamReader(getFilePath(saveFileName));
        string jsonString = sr.ReadToEnd();
        sr.Close();

        print(jsonString);

        JObject jObj = JObject.Parse(jsonString);
        name = jObj["data"]["name"].Value<string>();
        level = jObj["data"]["level"].Value<int>();
        friends = jObj["data"]["friends"].ToObject<string[]>();
    }

    private string getFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}

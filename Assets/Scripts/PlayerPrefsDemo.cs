using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDemo : MonoBehaviour
{
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
        PlayerPrefs.SetInt("myHp", 100);
        print("나의 체력 저장");
    }

    private void Load()
    {
        print("나의체력 불러옴 : " + PlayerPrefs.GetInt("myHp"));
    }
}

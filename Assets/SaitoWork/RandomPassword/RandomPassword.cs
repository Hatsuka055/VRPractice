using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPassword : MonoBehaviour
{
    /// <summary>
    /// Written Saito Takahiro
    /// </summary>
    public static RandomPassword instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public string password_A, password_B, password_C;
    public string KeyPassword;
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            if ((i % 3) == 0 && i != 0)//012,345,678
            {
                KeyPassword += ",";
            }
            KeyPassword += Random.Range(0, 10);
        }
        string[] SplitKeyPassword = KeyPassword.Split(',');
        password_A = SplitKeyPassword[0];
        password_B = SplitKeyPassword[1];
        password_C = SplitKeyPassword[2];
        KeyPassword = KeyPassword.Replace(",", "");
    }
}

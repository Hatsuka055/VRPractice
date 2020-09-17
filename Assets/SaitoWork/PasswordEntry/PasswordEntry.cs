using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PasswordEntry : MonoBehaviour
{

    /// <summary>
    /// Written Saito Takahiro
    /// </summary>
    [SerializeField] private GameObject TextObj = default;
    [SerializeField] [Header("SpawnPoint")] private GameObject BallSpawnPoint = default;
    [SerializeField] private GameObject MemopadSpawnPoint = default;
    [SerializeField] [Header("SpawnObjects")] private GameObject Ball = default;
    [SerializeField] private GameObject Memopad = default;
    TextMeshProUGUI TMP;
    int numberLength;
    Color tempC;

    bool isBlinking;
    void Start()
    {
        TMP = TextObj.GetComponent<TextMeshProUGUI>();
        numberLength = 0;
        tempC = TMP.faceColor;
        isBlinking = false;
    }

    public void number_input(int number)
    {
        if (8 < numberLength)
        {
            return;
        }
        numberLength++;
        TMP.text += number;
    }

    public void number_delete()
    {
        if (numberLength == 0)
        {
            return;
        }
        TMP.text = TMP.text.Remove(TMP.text.Length - 1, 1);
        numberLength--;
    }

    public void number_enter()
    {
        if (TMP.text == RandomPassword.instance.KeyPassword)
        {
            Instantiate(Ball, BallSpawnPoint.transform);
            Instantiate(Memopad, MemopadSpawnPoint.transform);
        }
        else
        {
            if (isBlinking == false)
            {
                StartCoroutine("InputError");
            }

        }
    }

    public IEnumerator InputError()
    {
        isBlinking = true;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            TMP.faceColor = Color.red;
            yield return new WaitForSecondsRealtime(0.1f);
            TMP.faceColor = tempC;
        }
        TMP.faceColor = tempC;
        isBlinking = false;
    }
}

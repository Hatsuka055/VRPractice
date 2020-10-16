using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PasswordDisplay : MonoBehaviour
{
    public enum passType { PasswordA, PasswordB, PasswordC, KeyPassword }
    public passType passtype;
    public TextMeshProUGUI TMP ;
    // Start is called before the first frame update
    void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
//        switch (passtype)
//        {
//            case passType.PasswordA: TMP.text = RandomPassword.instance.password_A; break;
//            case passType.PasswordB: TMP.text = RandomPassword.instance.password_B; break;
//            case passType.PasswordC: TMP.text = RandomPassword.instance.password_C; break;
//            case passType.KeyPassword: TMP.text = RandomPassword.instance.KeyPassword; break;
//            default: TMP.text = "null"; break;
//        }
		switch (passtype)
		{
			case passType.PasswordA: TMP.SetText(RandomPassword.instance.password_A); break;
			case passType.PasswordB: TMP.SetText(RandomPassword.instance.password_B); break;
			case passType.PasswordC: TMP.SetText(RandomPassword.instance.password_C); break;
			case passType.KeyPassword:TMP.SetText(RandomPassword.instance.KeyPassword); break;
			default: TMP.text = "null"; break;
		}
	}

	//なぜかパスワードが入らない問題の対処　by岡崎
	private void Update()
	{
		if (TMP.text == "")
		{
			switch (passtype)
			{
				case passType.PasswordA: TMP.text = RandomPassword.instance.password_A; break;
				case passType.PasswordB: TMP.text = RandomPassword.instance.password_B; break;
				case passType.PasswordC: TMP.text = RandomPassword.instance.password_C; break;
				case passType.KeyPassword: TMP.text = RandomPassword.instance.KeyPassword; break;
				default: TMP.text = "null"; break;
			}

		}
	}

}

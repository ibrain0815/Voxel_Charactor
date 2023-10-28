using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public GameObject loginPanel, selectPanel;
    public TMP_InputField idInput, pwInput, nickInput;


    private void Awake()
    {
        loginPanel.SetActive(true);
        selectPanel.SetActive(false);
    }

    public void Btn_Login()
    {
        if (UserData.userID == idInput.text && UserData.userPW ==pwInput.text )
        {
            loginPanel.SetActive(false );
            selectPanel.SetActive(true);
        }
    }

    public void Btn_Start()
    {
        if(!string.IsNullOrEmpty(nickInput.text) && UserData.charIndex !=99)
        {  
            UserData.nickName = nickInput.text;
            SceneManager.LoadScene("Build_it_1");

            //SceneManager.LoadScene("PlayScene");
            //print(UserData.nickName);
        }
    }
}

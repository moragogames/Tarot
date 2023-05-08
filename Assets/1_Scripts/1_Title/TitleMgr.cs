using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMgr : MonoBehaviour
{
    
    public void ClickEnterGame()
    {
        SceneManager.LoadScene("2_MenuScene");
    }

}

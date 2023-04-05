using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void LoadLevel(string LevelName)
    {
        GameManager.Instance.LoadScene(LevelName);
    }
}

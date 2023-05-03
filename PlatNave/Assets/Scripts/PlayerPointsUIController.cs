using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPointsUIController : MonoBehaviour
{
    private TMP_Text myText;

    private void OnEnable()
    {
        PlayerObserverManager.OnPointsChanged += UpdatePoints;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnPointsChanged -= UpdatePoints;
    }

    private void Awake()
    {
        myText = GetComponent<TMP_Text>();
    }

    private void UpdatePoints(int valor)
    {
        myText.text = valor.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuDisplayCoinsCollected : MonoBehaviour

{
    [SerializeField] Text textComponent; 
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = "Total coins collected: " + PlayerPrefs.GetInt("CoinAmount");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// A manager class that connects the menu scenes with the gameplay. 
public class SaveOptions : MonoBehaviour
{
    public static SaveOptions optionManager;
    private float mouseSen = 2;
    private bool isHardMode;
    public Slider slider;
    public TextMeshProUGUI mouseText;

    // Start is called before the first frame update
    void Start()
    {
        if (optionManager == null) {
            optionManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(optionManager);
        }
    }

    // Change mouse sen to the value of a slider
    public void changeMouseSen() {
        mouseSen = slider.value;
        mouseText.text = slider.value +"";
    }

    // Changes between hard/easy mode
    public void toggleMode(bool isHard) {
        isHardMode = isHard;
    }

    // Returns the mouse sen
    public float getMouseSen() {
        return mouseSen;
    }

    // Returns true if it's hard mode, false if it's easy
    public bool getMode() {
        return isHardMode;
    }
}

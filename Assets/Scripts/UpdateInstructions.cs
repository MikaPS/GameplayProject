using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpdateInstructions : MonoBehaviour
{
    public static UpdateInstructions textManager;
    public TextMeshProUGUI textInstructions;
    public TextMeshProUGUI end;

    public Canvas can;
    // Start is called before the first frame update
    void Start()
    {
        if (textManager == null)
            textManager = this;
        else
            Destroy(textManager);
    }

    // Change instructions text to the argument
    public void updateText(string txt) {
        textInstructions.text = txt;
    }

    // Display different text depends on the end game condition
    public void isWinning(bool isWin) {
        textInstructions.text = "";
        if (isWin) { end.text = "YOU WON!"; }
        else { end.text = "YOU LOST!"; }
        // Make the canvas visible
        can.GetComponent<Canvas> ().enabled = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class modeButtonText : MonoBehaviour
{
    Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "To Game Mode";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void currentGameMode(gameControl.game_mode currentMode)
    {
        if (currentMode == gameControl.game_mode.Edit)
            txt.text = "To Game Mode";
        else
            txt.text = "To Edit Mode";
    }
}

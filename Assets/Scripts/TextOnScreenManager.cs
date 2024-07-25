using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnScreenManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<TextOnScreen> txtOnScreen = new List<TextOnScreen>();

    private void Update()
    {
        // Call the UpdateTextOnScreen method for each text object currently on screen
        foreach (TextOnScreen txt in txtOnScreen)
            txt.UpdateTextOnScreen();
    }

    // Show a new text object on screen
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        // Get an available TextOnScreen object or create a new one if none are available
        TextOnScreen txtOnScreen = GetTextOnScreen();

        // Set the text, font size, and color of the text object
        txtOnScreen.txt.text = msg;
        txtOnScreen.txt.fontSize = fontSize;
        txtOnScreen.txt.color = color;

        // Set the position, motion, and duration of the text object
        txtOnScreen.go.transform.position = Camera.main.WorldToScreenPoint(position);
        txtOnScreen.motion = motion;
        txtOnScreen.duration = duration;

        // Show the text object on screen
        txtOnScreen.Show();
    }

    // Get an available TextOnScreen object or create a new one if none are available
    private TextOnScreen GetTextOnScreen()
    {
        TextOnScreen txt = txtOnScreen.Find(t => !t.active);

        if (txt == null)
        {
            txt = new TextOnScreen();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            txtOnScreen.Add(txt);
        }

        return txt;
    }
}

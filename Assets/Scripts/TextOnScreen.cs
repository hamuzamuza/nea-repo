using UnityEngine;
using UnityEngine.UI;

public class TextOnScreen
{
    public bool active; // Determines whether text is being displayed or not
    public GameObject go; // GameObject that represents the text object
    public Text txt; // Text component of GameObject
    public Vector3 motion; // Direction and speed that text will move on screen
    public float duration; // Duration of text appearance
    public float lastShown; // Time when text was last shown

    // This method is used to show the text on the screen
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    // This method is used to hide the text on the screen
    public void Hide()
    {
        active = false;
        go.SetActive(active);
    } 

    // This method is called to update the position of the text on the screen
    public void UpdateTextOnScreen()
    {
        if (!active)
            return;

        // If duration has elapsed
        if (Time.time - lastShown > duration)
            Hide();

        // Move the text on screen by motion * time elapsed since last frame
        go.transform.position += motion * Time.deltaTime;
    }
}

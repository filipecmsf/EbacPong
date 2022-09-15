using UnityEngine;
using UnityEngine.UI;

public class ButtonColorController : MonoBehaviour
{
    public PlayerSettingsController playerSettings;
    public Color customColor;

    private void Awake()
    {
        var colors = GetComponent<Button>().colors;

        colors.normalColor = customColor;
        
        GetComponent<Button>().colors = colors;
    }

    public void OnClick()
    {
        playerSettings.SetNewColor(newColor: customColor);
    }
}

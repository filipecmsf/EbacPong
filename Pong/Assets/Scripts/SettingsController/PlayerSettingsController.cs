using UnityEngine;
using TMPro;

public class PlayerSettingsController : MonoBehaviour
{
    private Player model;
    public TMP_InputField playerNameTextField;

    private void Awake()
    {
        model = new Player();
        model.Setup();
    }

    public void SetNewColor(Color newColor)
    {
        model.customColor = newColor;
    }

    public Color GetCustomColor()
    {
        return model.customColor;
    }

    public string GetName()
    {
        return playerNameTextField.text;
    }
}

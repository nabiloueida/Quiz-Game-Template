using TMPro;
using UnityEngine;

public class FloatVariableBinding : MonoBehaviour
{
    [SerializeField] private FloatVariable _observedVariable;

    [SerializeField] private TextMeshProUGUI _displayText;

    #region MonoBehaviour Methods
    private void OnEnable()
    {
        _observedVariable.VariableUpdated += UpdateDisplayText;
    }
    private void Start()
    {
        UpdateDisplayText();
    }
    private void OnDisable()
    {
        _observedVariable.VariableUpdated -= UpdateDisplayText;
    }
    #endregion

    private void UpdateDisplayText()
    {
        string displayString;
        if (_observedVariable.Value > 0.0f)
        {
            displayString =
                string.Format("{0:0}:{1:00}",
                Mathf.FloorToInt(_observedVariable.Value / 60),
                Mathf.FloorToInt(_observedVariable.Value % 60));
        }
        else
        {
            displayString = "0:00";
        }

        _displayText.text = displayString;
    }
}

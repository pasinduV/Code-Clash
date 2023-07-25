using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.SceneManagement;

public class RobotSourceCodeEditor : MonoBehaviour
{

    private UIDocument _doc;
    private Button _executeButton;
    private Button _clearButton;


    private TextField _textField;
    public RuntimeScriptable RuntimeScriptableObject;

    public Label _levelLabel;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _textField = _doc.rootVisualElement.Q<TextField>("TextField");
        _executeButton = _doc.rootVisualElement.Q<Button>("ExecuteButton");
        _clearButton = _doc.rootVisualElement.Q<Button>("ClearButton");

        _executeButton.clicked += OnCompileAndRunClick;
        _clearButton.clicked += clearTexts;

        _levelLabel = _doc.rootVisualElement.Q<Label>("levelNumber");

        string sceneName = SceneManager.GetActiveScene().name;
        _levelLabel.text = sceneName;

    }

    public void OnCompileAndRunClick()
    {
        if (RuntimeScriptableObject != null)
        {
            RuntimeScriptableObject.CompileAndRun(_textField.text);
        }
    }

    public void clearTexts()
    {
        if (RuntimeScriptableObject != null)
        {
            _textField.value = "";
        }
    }

}

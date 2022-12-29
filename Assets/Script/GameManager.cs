using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("InputField")] InputField _inputField = null;
    [SerializeField, Tooltip("表示用テキスト")] Text _text;
    string[] _textList = null;

    public void UpdateText()
    {
        _textList = new string[_inputField.text.Length];
        _text.text = null;
        for (int i = 0; i < _inputField.text.Length; i++)
        {
            var inputText = _inputField.text.Substring(i, 1);
            _textList[i] = inputText;
        }
        foreach (var input in _textList)
        {
            _text.text += $"{input}\n";
        }
    }
}

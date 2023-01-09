using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("InputField")] 
    private InputField _inputField = null;
    [SerializeField, Tooltip("表示用テキスト")]
    private Text _text;
    [SerializeField]
    private GameObject _fudeImage;
    [SerializeField]
    private Canvas _canvas;
    [SerializeField] 
    private GameObject _line;
    [SerializeField]
    private float _zPos = 10.0f;
    [SerializeField] 
    private float _yPos = 150f;
    [SerializeField] 
    private float _imageYpos = 15;

    private GameObject[] _lineRenderers;
    private int _index = 0, positionCount = 0;
    private string[] _textList = null;
    private bool _fude = false ,_fast = false;
    private Vector2 MousePos;
    private RectTransform _canvasRect;

    private void Start()
    {
        _lineRenderers = new GameObject[16];
        _canvasRect = _canvas.GetComponent<RectTransform>();
        _index = 0;
    }
    void Update()
    {
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10;
        transform.rotation = Camera.main.transform.rotation;
        
        if (Input.GetMouseButtonDown(0) && _fude)
        {
            var _obj = Instantiate(_line);
            _obj.transform.parent = transform;
            _lineRenderers[_index] = _obj;
            positionCount = 0;
        }
        if(Input.GetMouseButtonUp(0) && _fude) 
        {
            if (!_fast) { _fast = true; return; } 
            _index++; 
        }

        if (Input.GetMouseButton(0) && _fude)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = _zPos;
            pos.y += _yPos;
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos = transform.InverseTransformPoint(pos);

            positionCount++;
            _lineRenderers[_index].GetComponent<LineRenderer>().positionCount = positionCount;
            _lineRenderers[_index].GetComponent<LineRenderer>().SetPosition(positionCount - 1, pos);
        }

        if(_fude)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, Input.mousePosition, _canvas.worldCamera, out MousePos);
            _fudeImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(MousePos.x, MousePos.y);
        }
        if (Input.GetMouseButtonDown(1)) { Fude(); }
    }
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
    public void Fude()
    {
        _fude = false;
        if (!(_lineRenderers[0] == null))
        {
            foreach (var obj in _lineRenderers) {obj.SetActive(false); }
        }
        _fude = true;
        _fudeImage.SetActive(true);
        Cursor.visible = false;
         _index = 0;
    }
}

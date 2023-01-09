using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("InputField")] InputField _inputField = null;
    [SerializeField, Tooltip("�\���p�e�L�X�g")] Text _text;
    [SerializeField] GameObject _line;
    string[] _textList = null;
    GameObject[] _lineRenderers;
    int _index = 0;
    bool _fast = false;
    GameObject _obj;
    int positionCount = 0;

    void Update()
    {
        // ���̃��C���I�u�W�F�N�g���A�ʒu�̓J�����O��10m�A��]�̓J�����Ɠ����ɂȂ�悤�L�[�v������
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10;
        transform.rotation = Camera.main.transform.rotation;
        
        if (Input.GetMouseButtonDown(0)/* && !_fast*/)
        {
            _lineRenderers = new GameObject[30];
            _obj = Instantiate(_line);
            _obj.GetComponent<LineRenderer>().useWorldSpace = false;
            _lineRenderers[_index] = _obj;
            //_fast = true;
        }
        if (Input.GetMouseButton(0))
        {
            // ���W�w��̐ݒ�����[�J�����W�n�ɂ������߁A�^������W�ɂ����������
            Vector3 pos = Input.mousePosition;
            pos.z = 10.0f;

            // �}�E�X�X�N���[�����W�����[���h���W�ɒ���
            pos = Camera.main.ScreenToWorldPoint(pos);

            // ����ɂ�������[�J�����W�ɒ����B
            pos = transform.InverseTransformPoint(pos);

            // ����ꂽ���[�J�����W�����C�������_���[�ɒǉ�����
            positionCount++;
            _obj.GetComponent<LineRenderer>().positionCount = positionCount;
            _obj.GetComponent<LineRenderer>().SetPosition(positionCount - 1, pos);
        }
        //���Z�b�g����
        if (Input.GetMouseButton(1))
        {
            foreach (var obj in _lineRenderers) { obj.SetActive(false); }
            //_fast = false;
            _obj = null;
            positionCount = 0;
        }
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
}

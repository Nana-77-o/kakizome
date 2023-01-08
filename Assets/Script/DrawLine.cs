using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    //private LineRenderer lineRenderer;
    //private int positionCount;
    private Camera mainCamera;
    private float deltaTime = 0;
    private float touchInterval = 0.05f;
    private bool touchEnable = true;


    public GameObject lineObject;
    private LineRenderer lineRenderer;
    private int lineIndex = 1;
    private bool controll = true;
    //void Start()
    //{
    //    lineRenderer = GetComponent<LineRenderer>();
    //    // ���C���̍��W�w����A���̃��C���I�u�W�F�N�g�̃��[�J�����W�n����ɂ���悤�ݒ��ύX
    //    // ���̏�ԂŃ��C���I�u�W�F�N�g���ړ��E��]������ƁA�`���ꂽ���C�������[���h��ԂɎ��c����邱�ƂȂ��A�ꏏ�Ɉړ��E��]
    //    lineRenderer.useWorldSpace = false;
    //    positionCount = 0;
    //    mainCamera = Camera.main;
    //}

    //void Update()
    //{
    //    // ���̃��C���I�u�W�F�N�g���A�ʒu�̓J�����O��10m�A��]�̓J�����Ɠ����ɂȂ�悤�L�[�v������
    //    transform.position = mainCamera.transform.position + mainCamera.transform.forward * 10;
    //    transform.rotation = mainCamera.transform.rotation;

    //    if (Input.GetMouseButton(0))
    //    {
    //        // ���W�w��̐ݒ�����[�J�����W�n�ɂ������߁A�^������W�ɂ����������
    //        Vector3 pos = Input.mousePosition;
    //        pos.z = 10.0f;

    //        // �}�E�X�X�N���[�����W�����[���h���W�ɒ���
    //        pos = mainCamera.ScreenToWorldPoint(pos);

    //        // ����ɂ�������[�J�����W�ɒ����B
    //        pos = transform.InverseTransformPoint(pos);

    //        // ����ꂽ���[�J�����W�����C�������_���[�ɒǉ�����
    //        positionCount++;
    //        lineRenderer.positionCount = positionCount;
    //        lineRenderer.SetPosition(positionCount - 1, pos);
    //    }
    //    //���Z�b�g����
    //    if (Input.GetMouseButton(1))
    //    {
    //        positionCount = 0;
    //    }
    //}
    


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Debug.Log(lineRenderer);
        lineRenderer.enabled = false;
        mainCamera = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButton(0) && touchEnable && controll)
        {
            touchEnable = false;
            touch();
        }


        //if (Input.GetMouseButtonUp(0))
        //{
        //    controll = false;
        //}


        deltaTime += Time.deltaTime;
        if (deltaTime > touchInterval)
        {
            deltaTime = 0;
            touchEnable = true;
        }
    }


    void touch()
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f;
        var worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        Debug.Log(worldPoint);


        lineRenderer.enabled = true;
        lineRenderer.SetVertexCount(lineIndex);
        lineRenderer.SetPosition(lineIndex - 1, worldPoint);
        lineIndex++;
    }
}
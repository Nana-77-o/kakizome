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
    //    // ラインの座標指定を、このラインオブジェクトのローカル座標系を基準にするよう設定を変更
    //    // この状態でラインオブジェクトを移動・回転させると、描かれたラインもワールド空間に取り残されることなく、一緒に移動・回転
    //    lineRenderer.useWorldSpace = false;
    //    positionCount = 0;
    //    mainCamera = Camera.main;
    //}

    //void Update()
    //{
    //    // このラインオブジェクトを、位置はカメラ前方10m、回転はカメラと同じになるようキープさせる
    //    transform.position = mainCamera.transform.position + mainCamera.transform.forward * 10;
    //    transform.rotation = mainCamera.transform.rotation;

    //    if (Input.GetMouseButton(0))
    //    {
    //        // 座標指定の設定をローカル座標系にしたため、与える座標にも手を加える
    //        Vector3 pos = Input.mousePosition;
    //        pos.z = 10.0f;

    //        // マウススクリーン座標をワールド座標に直す
    //        pos = mainCamera.ScreenToWorldPoint(pos);

    //        // さらにそれをローカル座標に直す。
    //        pos = transform.InverseTransformPoint(pos);

    //        // 得られたローカル座標をラインレンダラーに追加する
    //        positionCount++;
    //        lineRenderer.positionCount = positionCount;
    //        lineRenderer.SetPosition(positionCount - 1, pos);
    //    }
    //    //リセットする
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
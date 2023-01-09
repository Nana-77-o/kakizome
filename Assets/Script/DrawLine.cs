using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
	private float deltaTime = 0;
	private float touchInterval = 0.05f;
	private bool touchEnable = true;


	public GameObject lineObject;
	private LineRenderer lineRenderer;
	private int lineIndex = 1;


	private bool controll = true;


	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		Debug.Log(lineRenderer);
		lineRenderer.enabled = false;
	}


	private void Update()
	{
		if (Input.GetMouseButton(0) && touchEnable && controll)
		{
			touchEnable = false;
			touch();
		}


		if (Input.GetMouseButtonUp(0))
		{
			controll = false;
		}


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
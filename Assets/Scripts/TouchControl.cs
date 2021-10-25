using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour {
    private Vector3 touchStart;

    public Camera cam;
    
    public float zoomOutMin = 2;
    public float zoomOutMax = 5;

    private float areaMinX, areaMaxX, areaMinY, areaMaxY;

    public SpriteRenderer area;

    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;
    private PointerEventData pointerData;

    private void Awake() {
        areaMinX = area.transform.position.x - area.bounds.size.x / 2f;
        areaMaxX = area.transform.position.x + area.bounds.size.x / 2f;
        
        areaMinY = area.transform.position.y - area.bounds.size.y / 2f;
        areaMaxY = area.transform.position.y + area.bounds.size.y / 2f;

        pointerData = new PointerEventData(null);
    }

    void Update() {

        if(Input.GetMouseButtonDown(0)){
            if (ClickOnUI()) {
                return;
            }
            touchStart = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        
        if(Input.touchCount == 2){
            if (ClickOnUI()) {
                return;
            }
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }else if(Input.GetMouseButton(0)){
            if (ClickOnUI()) {
                return;
            }
            
            Vector3 direction = touchStart - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += direction;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment) {
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - increment, zoomOutMin, zoomOutMax);
        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition) {
        float camHeight = cam.orthographicSize;
        float camWidht = cam.orthographicSize * cam.aspect;

        float minX = areaMinX + camWidht;
        float maxX = areaMaxX - camWidht;
        float minY = areaMinY + camHeight;
        float maxY = areaMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }

    private bool ClickOnUI() {
        pointerData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerData, results);

        if (results.Count > 0) {
            return true;
        }

        return false;
    }

}
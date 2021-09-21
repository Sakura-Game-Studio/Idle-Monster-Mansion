using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    private bool isOpen = false;

    private RectTransform rectTransform;

    [SerializeField] private Vector2 openPos;
    [SerializeField] private Vector2 closedPos;
    private float timeOfTravel = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        CloseTab();
    }

    public void ToggleTab()
    {
        SendMessage("Play");
        if (isOpen)
            CloseTab();
        else
            OpenTab();
    }

    private void OpenTab()
    {
        isOpen = true;
        //rectTransform.anchoredPosition = Vector2.Lerp(closedPos, openPos, 500f);
        StartCoroutine(LerpObject(closedPos, openPos));
    }

    IEnumerator LerpObject(Vector2 startPos, Vector2 endPos)
    {
        Debug.Log("Start Lerp");
        float currentTime = 0;
        float normalizedValue;
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;
            
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, normalizedValue);

            yield return null;
        }
        Debug.Log("End Lerp");
    }

    private void CloseTab()
    {
        isOpen = false;
        //rectTransform.anchoredPosition = Vector2.Lerp(openPos, closedPos, 500f);
        StartCoroutine(LerpObject(openPos, closedPos));
    }
}

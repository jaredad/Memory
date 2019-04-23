using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickNew : MonoBehaviour, IPointerClickHandler
{
    public string scene;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(scene);
    }
}
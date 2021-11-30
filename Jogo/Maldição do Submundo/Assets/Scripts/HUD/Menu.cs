using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Teleporter))]
[RequireComponent(typeof(CanvasGroup))]
public class Menu : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _initialMenuButton;
    [SerializeField] private int _sortingLayer;

    private Teleporter _teleporter;
    private CanvasGroup _canvasGroup;
    private Canvas _canvas;

    public bool IsPaused { get; private set; }

    void Start ()
    {
        _teleporter = GetComponent<Teleporter>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvas = GetComponent<Canvas>();

        Pause(false);

        _continueButton.onClick.AddListener(Continue);
        _initialMenuButton.onClick.AddListener(BackToMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(!IsPaused);
        }
    }

    void Pause (bool value)
    {
        IsPaused = value;
        Time.timeScale = value ? 0 : 1;
        _canvasGroup.alpha = value ? 1 : 0;
        _canvas.sortingOrder = value ? _sortingLayer : - _sortingLayer;
    }

    void Continue ()
    {
        Pause(false);
    }

    void BackToMenu ()
    {
        _teleporter.changeScene();
    }
}
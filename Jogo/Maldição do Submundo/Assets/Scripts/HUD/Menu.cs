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

    private Teleporter _teleporter;
    private CanvasGroup _canvasGroup;

    public bool IsPaused { get; private set; }

    void Start ()
    {
        _teleporter = GetComponent<Teleporter>();
        _canvasGroup = GetComponent<CanvasGroup>();

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
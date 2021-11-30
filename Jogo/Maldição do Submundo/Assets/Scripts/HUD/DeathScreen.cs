using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Teleporter))]
public class DeathScreen : MonoBehaviour, HUDState
{
    private HUDController _ctx;

    [SerializeField] private Button _button;
    private Teleporter _teleporter;

    public void EnterState(HUDController ctx)
    {
        _ctx = ctx;
        gameObject.SetActive(true);
    }

    public void OnStateExit()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {   
        gameObject.SetActive(false);
        _teleporter = GetComponent<Teleporter>();
        _button.onClick.AddListener(_teleporter.changeScene);
    }

    void Update()
    {        
    }
}

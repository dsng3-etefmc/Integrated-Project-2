using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalInterface : MonoBehaviour, HUDState
{
    [SerializeField] private Slider _healthBar;

    private HUDController _ctx;

    void Start ()
    {
        gameObject.SetActive(false);
    }

    void Update ()
    {
        _healthBar.value = Player.current.Health.getPercentage();
    }

    public void EnterState(HUDController ctx)
    {
        gameObject.SetActive(true);
        // Player.current.Health.onHeathChange += OnPlayerHealthChange;
        _ctx = ctx;
    }

    public void OnStateExit()
    {
        gameObject.SetActive(false);
        // Player.current.Health.onHeathChange -= OnPlayerHealthChange;
    }

    void OnPlayerHealthChange (Health health) 
    {
        UpdateHealthbar(health.getPercentage());
    }

    void UpdateHealthbar(float newHealth) 
    {
        _healthBar.value = newHealth;
    }
}

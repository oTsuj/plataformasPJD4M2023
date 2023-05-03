using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerInput _playerInput;
    private GameControls _gameControls;
    private Vector2 _moveInput;
    private bool _isShooting;

    private int _currentEnergy;
    [SerializeField] private int maxEnergy;
    private int _points;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnAction;
    }

    private void OnAction(InputAction.CallbackContext playerAct)
    {
        if (playerAct.action.name == _gameControls.Gameplay.Shoot.name)
        {
            // faz o jogador atirar
            
            //GetButtonDown > Ativa no momento que o botao é apertado
            //GetButton > Fica ativo enquanto o botao estiver apertado
            //GetButtonUp > Ativa no momento que o botao é solto
            
            //startde > Ativa no momento que o botao é apertado
            //canceled > Ativa no momento que o botao é solto
            
            //performed > Ativa no momento qu o botao é apertado esolto

            if (playerAct.started) _isShooting = true;
            if (playerAct.canceled) _isShooting = false;
        }

        if (playerAct.action.name == _gameControls.Gameplay.Move.name)
        {
            // faz o jogador se mover
            _moveInput = playerAct.ReadValue<Vector2>();
        }
    }

    private void AddEnergy(int amount)
    {
        _currentEnergy = Mathf.Clamp(_currentEnergy + amount, 0, maxEnergy);
    }

    private void AddPoints(int amount)
    {
        _points += amount;
        PlayerObserverManager.PointsChanged(_points);
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnAction;
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameControls = new GameControls();

        _currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.jKey.wasPressedThisFrame) AddEnergy(amount:10);
        
        if(Keyboard.current.kKey.wasPressedThisFrame) AddEnergy(amount:-10);
        
        if(Keyboard.current.lKey.wasPressedThisFrame) AddPoints(amount:100);
    }
}

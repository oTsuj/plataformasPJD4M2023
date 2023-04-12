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

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnAction;
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameControls = new GameControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

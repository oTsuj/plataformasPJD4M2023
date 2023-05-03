using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private int _maxEnergy;

    private int _currentEnergy;

    private Sprite _enemySprite;

    private SpriteRenderer _spriteRenderer;

    public void InitializeEnemy(int maxEnergy, Sprite enemySprite)
    {
        _maxEnergy = maxEnergy;
        _currentEnergy = _maxEnergy;

        _enemySprite = enemySprite;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer.sprite = _enemySprite;
    }
}

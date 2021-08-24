using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    public static EventManager instance;

    void Awake() {
        instance = this;
    }

    public event Action onPlayerDied;
    public void PlayerDied() {
        onPlayerDied?.Invoke();
    }

    public event Action onEnemyDied;
    public void EnemyDied() {
        onEnemyDied?.Invoke();
    }

    public event Action<int> onMoneyChanged;
    public void MoneyChanged(int newValue) {
        onMoneyChanged?.Invoke(newValue);
    }

    public event Action<float> onPlayerDamaged;
    public void PlayerDamaged(float percentRemaining) {
        onPlayerDamaged?.Invoke(percentRemaining);
    }
}
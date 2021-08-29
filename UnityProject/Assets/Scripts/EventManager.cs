using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    public static EventManager instance;

    void Awake() {
        instance = this;
    }

    public event Action onFXAAchanged;
    public void FXAAchanged() {
        onFXAAchanged?.Invoke();
    }
    
    public event Action onVolumeChanged;
    public void VolumeChanged() {
        onVolumeChanged?.Invoke();
    }
    
    public event Action onPlatformSpawned;
    public void PlatformSpawned() {
        onPlatformSpawned?.Invoke();
    }

    public event Action onPlatformDestroyed;
    public void PlatformDestroyed() {
        onPlatformDestroyed?.Invoke();
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
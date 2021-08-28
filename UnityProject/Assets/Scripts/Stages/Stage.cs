using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Stage")]
public class Stage : ScriptableObject {
    public float activationSecond;
    public int maxPlatformsOnMap;
    public float platformSpawnFrequency;
    [Range(0f, 1f)] public float enemySpawnChance;
    [Range(0f, 1f)] public float powerupSpawnChance;
    public int energyDropRate;
    public int moneyDropRate;
    public int randomDropOffset;
    public float enemyDamageMultiplier = 1f;
    public float enemyShotsPerSecond = 0.5f;
    public float lavaDamageMultiplier = 1f;
    public float enemyHealthMultiplier = 1f;
    public List<WeightedRandomBag<Transform>.Entry> platforms;
    public List<WeightedRandomBag<Transform>.Entry> enemies;
    public List<WeightedRandomBag<Transform>.Entry> powerups;
}
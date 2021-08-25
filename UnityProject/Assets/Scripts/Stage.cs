using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Stage")]
public class Stage : ScriptableObject {
    public float activationSecond;
    [Range(0f,1f)]
    public float spawnChance;
    public List<WeightedRandomBag<Transform>.Entry> platforms;
    public List<WeightedRandomBag<Transform>.Entry> enemies;
}
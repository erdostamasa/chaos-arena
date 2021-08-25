using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class WeightedRandomBag<T> {
    [Serializable]
    public struct Entry {
        public T item;
        public float accumulatedWeight;

        public Entry(T item, float accumulatedWeight) {
            this.item = item;
            this.accumulatedWeight = accumulatedWeight;
        }
    }

    List<Entry> entries = new List<Entry>();
    float accumulatedWeight;

    public void AddEntry(T item, float weight) {
        accumulatedWeight += weight;
        entries.Add(new Entry(item, accumulatedWeight));
    }

    public T GetRandom() {
        float chance = Random.Range(0f, 1f) * accumulatedWeight;
        foreach (Entry entry in entries) {
            if (entry.accumulatedWeight >= chance) {
                return entry.item;
            }
        }

        return default(T);
    }
}
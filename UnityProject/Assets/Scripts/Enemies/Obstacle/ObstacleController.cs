using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour {
    [SerializeField] float extendedHeight = 0.5f;
    [SerializeField] float retractedHeight = -1f;
    [SerializeField] float moveSpeed = 0.5f;
    bool extended = false;
    [SerializeField] LayerMask layers;

    float timer = 0f;
    [SerializeField] float minTtimeToChange = 5f;
    [SerializeField] float maxTtimeToChange = 10f;
    float timeToChange;
    [Range(0f, 1f), SerializeField] float chanceToStartExtended = 0.5f;

    void Start() {
        transform.position = new Vector3(transform.position.x, retractedHeight, transform.position.z);
        timeToChange = Random.Range(minTtimeToChange, maxTtimeToChange);

        if (chanceToStartExtended < Random.Range(0f, 1f)) {
            Extend();
        }
    }


    void Update() {
        timer += Time.deltaTime;
        if (timer >= timeToChange) {
            if (extended) {
                Retract();
                timeToChange = Random.Range(minTtimeToChange, maxTtimeToChange);
                timer = 0;
            }
            else if (!extended && CanExtend()) {
                Extend();
                timeToChange = Random.Range(minTtimeToChange, maxTtimeToChange);
                timer = 0;
            }
        }
    }

    public void Extend() {
        if (extended) return;
        transform.DOMoveY(extendedHeight, moveSpeed);
        extended = true;
    }

    public void Retract() {
        if (!extended) return;
        transform.DOMoveY(retractedHeight, moveSpeed);
        extended = false;
    }


    public bool CanExtend() {
        Collider[] contacts = new Collider[1];
        contacts = Physics.OverlapBox(transform.position, new Vector3(3f, 8f, 3f), Quaternion.identity, layers, QueryTriggerInteraction.Ignore);
        if (contacts.Length == 0) return true;
//        Debug.Log(contacts[0].name);
        return false;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;


        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        //if (m_Started)
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawWireCube(transform.position, new Vector3(6f, 16f, 6f));
    }
}
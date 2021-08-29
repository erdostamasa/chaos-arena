using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnPoint : MonoBehaviour {
    [SerializeField] Material visibleMaterial;
    [SerializeField] Material invisibleMaterial;
    [SerializeField] LayerMask layers;
    [SerializeField] bool losBlocks = true;
    
    void Update() {
        if (Visible()) {
            GetComponent<Renderer>().material = visibleMaterial;
        }
        else {
            GetComponent<Renderer>().material = invisibleMaterial;
        }
    }

    float margin = -0.1f;

    public bool Visible() {
        if (!losBlocks) return false;
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        //Debug.Log(screenPoint);
        return screenPoint.z > 0 && screenPoint.x > 0 - margin && screenPoint.x < 1 + margin && screenPoint.y > 0 - margin && screenPoint.y < 1 + margin;
    }

    public bool CanSpawn() {
        if (Visible()) return false;
        Collider[] contacts = new Collider[1];
        contacts = Physics.OverlapBox(transform.position, new Vector3(6f, 5f, 6f), Quaternion.identity, layers, QueryTriggerInteraction.Ignore);
        //Debug.Log(gameObject.name + " " + contacts.Length);
        if (contacts.Length == 0) return true;
        return false;
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        //if (m_Started)
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawWireCube(transform.position, new Vector3(12f, 10f, 12f));
    }
}
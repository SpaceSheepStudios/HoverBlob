using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresPosition : MonoBehaviour
{
    public float minRadius = 0.25f; // Mindest-Radius des Sphere Colliders
    public float maxRadius = 2f; // Maximaler Radius des Sphere Colliders
    private float currentRadius; // Aktueller Radius des Sphere Colliders

    private SphereCollider sphereCollider; // Referenz auf den Sphere Collider

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>(); // Hole die Komponente Sphere Collider

        // Initialisiere den Radius auf den Mindestwert
        currentRadius = minRadius;

        // Starte die Coroutine für das Ändern des Radius alle 2 Sekunden
        StartCoroutine(ChangeRadiusRoutine());
    }

    private System.Collections.IEnumerator ChangeRadiusRoutine()
    {
        while (true)
        {
            // Ändere den Radius auf den aktuellen Wert
            sphereCollider.radius = currentRadius;

            // Warte 2 Sekunden
            yield return new WaitForSeconds(4f);

            // Wenn der aktuelle Radius den Mindestwert erreicht hat, setze ihn auf den Maximalwert, ansonsten setze ihn auf den Mindestwert
            if (currentRadius == minRadius)
            {
                currentRadius = maxRadius;
            }
            else
            {
                currentRadius = minRadius;
            }
        }
    }
}

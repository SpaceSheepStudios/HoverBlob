using System.Collections;
using UnityEngine;

public class SlimeAttractor : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    public Transform centerPoint;
    public SphereCollider sphereCollider;
    public bool innen = false;
    public float pausetime1 = 2f;
    public float pausetime2 = 4f;
    public float kraftmultiA = 40f;
    public float kraftmultiZ = 20f;
    /*
    public float breathScaleAmount = 0.1f;
    public float breathInterval = 1f;
    */
    private Vector3 originalScale;

    private void Start()
    {
        // Kinder-Rigidbodies abrufen
        _rigidbodies = GetComponentsInChildren<Rigidbody>();

        // Ausgangsskalierung speichern
        originalScale = transform.localScale;

        // Coroutine starten
        StartCoroutine(MoveSlimes());
        //StartCoroutine(BreathEffect());
    }

    private IEnumerator Pause1()
    {
        Debug.Log("Vor der Pause1");

        yield return new WaitForSeconds(pausetime1); 

        Debug.Log("Nach der Pause1");

        // Nach der Pause die Slime-Bewegung umkehren
        innen = !innen;
        Debug.Log("Richtungswechsel1");

        // Coroutine erneut starten
        StartCoroutine(MoveSlimes());
    }

    private IEnumerator Pause2()
    {
        Debug.Log("Vor der Pause2");

        yield return new WaitForSeconds(pausetime2); 

        Debug.Log("Nach der Pause2");

        // Nach der Pause die Slime-Bewegung umkehren
        innen = !innen;
        Debug.Log("Richtungswechsel2");

        // Coroutine erneut starten
        StartCoroutine(MoveSlimes());
    }

    private IEnumerator MoveSlimes()
    {
        if (innen)
        {
            MoveAuseinander();
            StartCoroutine(Pause1());
            Debug.Log("move auseinander");
        }
        else
        {
            MoveZusammen();
            StartCoroutine(Pause2());
        }

        yield return null;
    }

    private void MoveAuseinander()
    {
        foreach (var rb in _rigidbodies)
        {
            var force = (centerPoint.position - rb.position).normalized;
            rb.AddForce(force * kraftmultiA); // Erhöhe die Kraft, um die Slimes schneller auseinander zu bewegen
            //Debug.Log("läuft auseinander.");
        }
    }

    private void MoveZusammen()
    {
        foreach (var rb in _rigidbodies)
        {
            var force = (centerPoint.position - rb.position).normalized;
            rb.AddForce(-(force * kraftmultiZ)); // Erhöhe die Kraft, um die Slimes schneller zusammenzubewegen
            //Debug.Log("läuft zusammen.");
        }
    }

/*
    private IEnumerator BreathEffect()
    {
        while (true)
        {
            yield return new WaitForSeconds(breathInterval);

            // Atmeffekt erzeugen
            StartCoroutine(ScaleSlimes(breathScaleAmount));
            yield return new WaitForSeconds(breathInterval);

            // Ursprüngliche Größe wiederherstellen
            StartCoroutine(ScaleSlimes(-breathScaleAmount));
        }
    }

    private IEnumerator ScaleSlimes(float scaleAmount)
    {
        float elapsedTime = 0f;
        float duration = 0.5f; // Dauer der Skalierungsanimation

        Vector3 targetScale = originalScale + new Vector3(scaleAmount, scaleAmount, scaleAmount);

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Sicherstellen, dass die Skala am Ende der Animation genau auf den Zielwert gesetzt wird
        transform.localScale = targetScale;
    }
    */
}

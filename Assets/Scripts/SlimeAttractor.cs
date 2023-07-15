using System.Collections;
using UnityEngine;

public class SlimeAttractor : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    public Transform centerPoint;
    public bool innen = false;
    public float pausetime1 = 2f;
    public float pausetime2 = 4f;
    public float kraftmultiA = 40f;
    public float kraftmultiZ = 20f;
    private Vector3 originalScale;

    private void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();

        // Store Scaling
        originalScale = transform.localScale;

        // Start Coroutine
        StartCoroutine(MoveSlimes());
    }

    private IEnumerator Pause1()
    {
        yield return new WaitForSeconds(pausetime1); 

        // switch movement directions after break
        innen = !innen;
        Debug.Log("Richtungswechsel1");

        // restart Coroutine
        StartCoroutine(MoveSlimes());
    }

    private IEnumerator Pause2()
    {
        yield return new WaitForSeconds(pausetime2);

        // switch movement directions after break
        innen = !innen;
        Debug.Log("Richtungswechsel2");

        // restart Coroutine
        StartCoroutine(MoveSlimes());
    }

    private IEnumerator MoveSlimes()
    {
        if (innen)
        {
            // moves bubbles apart
            MoveAuseinander();
            StartCoroutine(Pause1());
        }
        else
        {
            // moves bubbles together
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
            rb.AddForce(force * kraftmultiA); 
        }
    }

    private void MoveZusammen()
    {
        foreach (var rb in _rigidbodies)
        {
            var force = (centerPoint.position - rb.position).normalized;
            rb.AddForce(-(force * kraftmultiZ));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float forceFactor;
    public ParticleSystem explosionSfx;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float xForce = mousePosition.x - 0.5f;
            float yForce = mousePosition.y - 0.5f;
            float zForce = 0.0f;
            Vector3 force = new Vector3(xForce, yForce, zForce) * 2.0f;
            rb.AddForce(force * forceFactor);
        }
    }

    public void Exploit()
    {
        Instantiate(explosionSfx, transform.position, explosionSfx.transform.rotation).Play();
    }
}

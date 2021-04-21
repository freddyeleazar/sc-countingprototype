using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public float sphereLifeTime;
    public SphereController sphere;
    public Transform box;

    private SphereController currentSphere;
    private int spawningCounter = 0;

    private void Start()
    {
        StartCoroutine(SpawnSphereLoop());
    }

    private IEnumerator SpawnSphereLoop()
    {
        while (spawningCounter <= 15)
        {
            SpawnSphere();
            yield return new WaitForSeconds(sphereLifeTime);
            currentSphere.Exploit();
            Destroy(currentSphere.gameObject);
        }
    }

    private void SpawnSphere()
    {
        currentSphere = Instantiate(sphere.gameObject, GenerateRandomTopBoundPosition(), sphere.transform.rotation).GetComponent<SphereController>();
        spawningCounter++;
    }

    private Vector3 GenerateRandomTopBoundPosition()
    { 
        float xRandomViewportPos = Random.Range(0.0f, 1.0f);
        float yTopBoundViewportPos = 1.0f;
        float boxViewportPos = box.position.z - Camera.main.transform.position.z;

        Vector3 viewportRandomTopBoundPos = new Vector3(xRandomViewportPos, yTopBoundViewportPos, boxViewportPos);        
        Vector3 randomTopBoundPosition = Camera.main.ViewportToWorldPoint(viewportRandomTopBoundPos);

        return randomTopBoundPosition;
    }
}

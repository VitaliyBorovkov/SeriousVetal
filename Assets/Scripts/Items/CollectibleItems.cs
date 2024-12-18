using System;

using UnityEngine;
using UnityEngine.Events;

public class CollectibleItems : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 43f;
    [SerializeField] private float floatDistance = 0.5f;
    [SerializeField] private UnityEvent OnCollected;

    private bool floatingUp = true;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        var rotation = transform.rotation.eulerAngles;
        rotation.x = 0f;
        transform.rotation = Quaternion.Euler(rotation);


        float floatStep = floatDistance * Time.deltaTime;
        transform.position += (floatingUp ? Vector3.up : Vector3.down) * floatStep;

        if (transform.position.y > initialPosition.y + floatDistance)
        {
            floatingUp = false;
        }
        else if (transform.position.y < initialPosition.y)
        {
            floatingUp = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }

    public void Collect(GameObject player)
    {
        OnCollected.Invoke();
        gameObject.SetActive(false);
    }
}

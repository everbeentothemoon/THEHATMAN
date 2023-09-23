using System.Collections;
using UnityEngine;

public class timerPlatform : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;
    public float openDuration = 5f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isOpen = false;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + new Vector3(moveDistance, 0f, 0f);
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                StartCoroutine(CloseDoorAfterDelay());
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
        StopAllCoroutines();
        StartCoroutine(CloseDoorAfterDelay());
    }

    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(openDuration);
        isOpen = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;


    public bool IsSelected { get; private set; } = false;

    public void Select()
    {
        IsSelected = true;
        Debug.Log("Unit selected");
    }

    public void Deselect()
    {
        IsSelected = false;
        Debug.Log("Unit deselected");
    }

    public void Move(Vector3 groundPosition)
    {
        MoveTask(groundPosition);
    }

    private async Task MoveTask(Vector3 groundPosition)
    {
        Vector3 targetPosition = new Vector3(groundPosition.x, transform.position.y, groundPosition.z);
        transform.LookAt(targetPosition, Vector3.up);

        float distance = Vector3.Distance(targetPosition, transform.position);
        float stepDistance = _movementSpeed * Time.deltaTime;
        Vector3 direction = (targetPosition - transform.position).normalized;

        while (stepDistance < distance)
        {
            transform.position = transform.position + direction * stepDistance;
            distance = Vector3.Distance(targetPosition, transform.position);
            stepDistance = _movementSpeed * Time.deltaTime;

            await Task.Yield();
        }

        transform.position = targetPosition;
    }
}

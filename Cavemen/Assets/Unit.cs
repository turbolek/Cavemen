using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

    private CancellationTokenSource _moveCancelationToken;

    public bool IsSelected { get; private set; } = false;

    private void Start()
    {

    }

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
        if (_moveCancelationToken != null)
        {
            _moveCancelationToken.Cancel();
        }

        _moveCancelationToken = new CancellationTokenSource();
        MoveTask(groundPosition, _moveCancelationToken.Token);
    }

    private async Task MoveTask(Vector3 groundPosition, CancellationToken cancellationToken)
    {
        Vector3 targetPosition = new Vector3(groundPosition.x, transform.position.y, groundPosition.z);
        transform.LookAt(targetPosition, Vector3.up);

        float distance = Vector3.Distance(targetPosition, transform.position);
        float stepDistance = _movementSpeed * Time.deltaTime;
        Vector3 direction = (targetPosition - transform.position).normalized;

        while (stepDistance < distance && !cancellationToken.IsCancellationRequested)
        {
            transform.position = transform.position + direction * stepDistance;
            distance = Vector3.Distance(targetPosition, transform.position);
            stepDistance = _movementSpeed * Time.deltaTime;

            await Task.Yield();
        }

        if (!cancellationToken.IsCancellationRequested)
        {
            transform.position = targetPosition;
        }
    }
}

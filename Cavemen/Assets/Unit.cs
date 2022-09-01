using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _interactionCooldown = 1f;

    private CancellationTokenSource _moveCancelationToken;
    public IInteractable InteractionTarget { get; private set; }
    private Vector3 _targetPosition;

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

    public void SetTarget(IInteractable targetInteractable, Vector3 groundPosition)
    {
        InteractionTarget = targetInteractable;
        if (InteractionTarget != null)
        {
            _targetPosition = InteractionTarget.GetPosition();
        }
        else
        {
            _targetPosition = groundPosition;
        }

        Move();
    }

    private void Move()
    {
        if (_moveCancelationToken != null)
        {
            _moveCancelationToken.Cancel();
        }

        _moveCancelationToken = new CancellationTokenSource();
        MoveTask(_moveCancelationToken.Token);
    }

    private async Task MoveTask(CancellationToken cancellationToken)
    {
        Vector3 targetPosition = new Vector3(_targetPosition.x, transform.position.y, _targetPosition.z);
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

            UpdateTargetPosition();
        }

        if (!cancellationToken.IsCancellationRequested)
        {
            transform.position = targetPosition;
            OnTargetReached(cancellationToken);
        }
    }

    private void UpdateTargetPosition()
    {
        if (InteractionTarget != null)
        {
            _targetPosition = InteractionTarget.GetPosition();
        }
    }

    private void OnTargetReached(CancellationToken token)
    {
        InteractWithTarget(token);
    }

    private async Task InteractWithTarget(CancellationToken token)
    {

        if (InteractionTarget != null)
        {
            float cooldown = _interactionCooldown;
            while (!token.IsCancellationRequested && InteractionTarget.IsInteractable())
            {
                if (cooldown <= 0f)
                {
                    InteractionTarget.Interact();
                    cooldown = _interactionCooldown;
                }
                await Task.Yield();
                cooldown -= Time.deltaTime;
            }
        }
    }


}

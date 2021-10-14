using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Input _input;
    private Unit _selectedUnit;

    [SerializeField]
    private LayerMask _groundLayerMask;
    private Vector3 _mouseGroundPosition;
    private Vector3 _mouseWorldPosition;
    private Vector2 _mouseScreenPosition;

    void Start()
    {
        _input = new Input();

        InitGeneralActions();
        InitUnitActions();
    }

    private void InitGeneralActions()
    {
        _input.GeneralActions.Enable();

        _input.GeneralActions.UpdateMousePosition.performed += ctx => UpdateMousePosition(ctx.ReadValue<Vector2>());
        _input.GeneralActions.Select.performed += ctx => OnSelectAction();
    }

    private void InitUnitActions()
    {
        _input.UnitActions.Disable();
        _input.UnitActions.Move.performed += ctx =>
        {
            OnUnitMoveAction();
        };
    }

    private void OnSelectAction()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(_mouseScreenPosition);

        Physics.Raycast(ray, out hit);

        Unit hitUnit = null;

        if (hit.transform != null)
        {
            hitUnit = hit.transform.GetComponent<Unit>();
        }

        if (hitUnit != null)
        {
            SelectUnit(hitUnit);
        }
        else
        {
            DeselectUnit();
        }
    }

    private void SelectUnit(Unit unit)
    {
        DeselectUnit();

        _input.UnitActions.Enable();
        unit.Select();
        _selectedUnit = unit;
    }

    private void DeselectUnit()
    {
        _input.UnitActions.Disable();

        if (_selectedUnit != null)
        {
            _selectedUnit.Deselect();
        }
    }

    private void UpdateMousePosition(Vector2 mouseScreenPosition)
    {
        _mouseScreenPosition = mouseScreenPosition;
        _mouseWorldPosition = _camera.ScreenToWorldPoint(mouseScreenPosition);

        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(_mouseScreenPosition);

        Physics.Raycast(ray, out hit, _groundLayerMask);

        if (hit.transform != null)
        {
            _mouseGroundPosition = hit.point;
        }
    }

    private void OnUnitMoveAction()
    {
        if (_selectedUnit != null)
        {
            _selectedUnit.Move(_mouseGroundPosition);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_mouseWorldPosition, .25f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_mouseGroundPosition, .25f);
    }
}

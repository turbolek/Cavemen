using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Input _input;
    private Unit _selectedUnit;
    private Vector3 _mouseWorldPosition;
    private Vector2 _mouseScreenPosition;

    void Start()
    {
        InitGeneralActions();
    }

    private void InitGeneralActions()
    {
        _input = new Input();
        _input.GeneralActions.Enable();

        _input.GeneralActions.UpdateMousePosition.performed += ctx => UpdateMousePosition(ctx.ReadValue<Vector2>());
        _input.GeneralActions.Select.performed += ctx => OnSelectAction();
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
        unit.Select();
        _selectedUnit = unit;
    }

    private void DeselectUnit()
    {
        if (_selectedUnit != null)
        {
            _selectedUnit.Deselect();
        }
    }

    private void UpdateMousePosition(Vector2 mouseScreenPosition)
    {
        _mouseScreenPosition = mouseScreenPosition;
        _mouseWorldPosition = _camera.ScreenToWorldPoint(mouseScreenPosition);
    }
}

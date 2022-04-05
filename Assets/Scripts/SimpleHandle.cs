using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleHandle : XRGrabInteractable
{
    public float breakDistance = 1.0f;
    public XRGrabInteractable interactable = null;

    private void Start()
    {
        interactable.selectEntered.AddListener(Show);
        interactable.selectExited.AddListener(Hide);
        Hide(null);
    }

    protected override void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(Show);
        interactable.selectExited.RemoveListener(Hide);
    }

    private void Show(SelectEnterEventArgs args)
    {
        gameObject.SetActive(true);
    }

    private void Hide(SelectExitEventArgs args)
    {
        gameObject.SetActive(false);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs selectEnterEventArgs)
    {
        SetTracking(false);
    }

    protected override void OnSelectExiting(SelectExitEventArgs selectExitEventArgs)
    {
        SetTracking(true);
        ResetPosition();
    }

    private void SetTracking(bool value)
    {
        interactable.trackPosition = value;
        interactable.trackRotation = value;
    }

    private void ResetPosition()
    {
        transform.localPosition = Vector3.up;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (CanBeUpdated())
            {
                Vector3 direction = CalculateDirection();
                UpdatePosition(direction);
                UpdateRotation(direction);
                UpdateSize(direction.magnitude);
                BreakCheck(direction);
            }
        }
    }

    private bool CanBeUpdated()
    {
        return isSelected && interactable.isSelected;
    }

    private Vector3 CalculateDirection()
    {
        Vector3 parentPosition = interactable.selectingInteractor.transform.position;
        Vector3 handlePosition = transform.position;
        return handlePosition - parentPosition;
    }

    private void UpdatePosition(Vector3 direction)
    {
        Vector3 parentPosition = interactable.selectingInteractor.transform.position;
        Vector3 finalPosition = parentPosition + (direction * 0.5f);
        interactable.transform.position = finalPosition;
    }

    private void UpdateRotation(Vector3 direction)
    {
        Vector3 cross = Vector3.Cross(direction, Vector3.up);
        Quaternion finalRotation = Quaternion.LookRotation(cross, Vector3.up);
        interactable.transform.rotation = finalRotation;
    }

    private void UpdateSize(float targetWidth)
    {
        targetWidth *= 0.5f;

        float currentWidth = colliders[0].bounds.size.x;
        float newScale = targetWidth * transform.localScale.x / currentWidth;
        Vector3 finalScale = new Vector3(newScale, newScale, newScale);

        interactable.transform.localScale = finalScale;
    }

    private void BreakCheck(Vector3 direction)
    {
        if (direction.magnitude > breakDistance)
        {
            SetTracking(true);
            ResetPosition();
        }
    }
}

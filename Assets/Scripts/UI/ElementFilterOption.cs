using UnityEngine;

public class ElementFilterOption : FilterOption
{
    [SerializeField] private Element element;

    public override void OnSelect()
    {
        OnApplyFilter?.Invoke(element);
    }
}

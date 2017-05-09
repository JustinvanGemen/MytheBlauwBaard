using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGridVisual : MonoBehaviour
{
    private bool _show;

    [SerializeField] private GameObject _visualContainer;
    [SerializeField] private Image _itemVisualPrefab;

    private List<Image> _itemVisuals;

    private void Awake()
    {
        _itemVisuals = new List<Image>();
    }

    private void Update()
    {
        if (!_show)
        {
            if (!_visualContainer.activeSelf)
            {
                return;
            }
            else
            {
                _visualContainer.SetActive(false);
            }
        } else if (_show)
        {
            if (_visualContainer.activeSelf)
            {
                return;
            }
            else
            {
                _visualContainer.SetActive(true);
            }
        }
    }

    public void Init(Inventory inventory)
    {
        inventory.RegisterOnChanged(Repaint);

        for (int i = 0; i < 9; i++)
        {
            var visual = Instantiate(_itemVisualPrefab);
            visual.transform.SetParent(_visualContainer.transform);

            _itemVisuals.Add(visual);
        }

        Repaint(inventory);
    }

    public void Toggle()
    {
        _show = !_show;
    }

    public void Repaint(Inventory inventory)
    {
        for (int i = 0; i < _itemVisuals.Count; i++)
        {
            _itemVisuals[i].sprite = null;
        }

        for (int i = 0; i < inventory.Items.Count; i++)
        {
            _itemVisuals[i].sprite = Resources.Load<Sprite>("Items/" + inventory.Items[i].Name);
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    public Color hoverColor;
    public Vector3 positionOffset;

    private BuildManager _buildManager;
    private GameObject _tower;
    private Renderer _renderer;
    private Color _defaultColor;

    void Start()
    {
        _buildManager = BuildManager.instance;
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (_buildManager.GetTowerToBuild() == null) {
            return;
        }

        if (_tower != null) {
            Debug.Log("Cannot build here!");
            return;
        }

        GameObject towerToBuild = _buildManager.GetTowerToBuild();
        _tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (_buildManager.GetTowerToBuild() == null)
        {
            return;
        }

        _renderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        _renderer.material.color = _defaultColor;
    }
}

using UnityEngine;

public class Shop : MonoBehaviour {

    private BuildManager _buildManager;

    void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTower() {
        _buildManager.SetTowerToBuild(_buildManager.standardTowerPrefab);
    }
}

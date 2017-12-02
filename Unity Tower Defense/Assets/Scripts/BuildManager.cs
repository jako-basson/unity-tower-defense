using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private GameObject _towerToBuild;

    public GameObject standardTowerPrefab;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one build manager in scene!");
        }
        instance = this;
    }

    public GameObject GetTowerToBuild() {
        return _towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower) {
        _towerToBuild = tower;
    }
}

using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 10f;

    private Transform _target;
    private int _wavepointIndex = 0;

    void Start()
    {
        _target = WaypointsController.points[_wavepointIndex];    
    }

    void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f) {
            SetNextWayPoint();
        }
    }

    void SetNextWayPoint() {
        if (_wavepointIndex >= WaypointsController.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        _wavepointIndex++;
        _target = WaypointsController.points[_wavepointIndex];
    }
}

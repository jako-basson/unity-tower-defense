using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = WaypointsController.points[wavepointIndex];    
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
            SetNextWayPoint();
        }
    }

    void SetNextWayPoint() {
        if (wavepointIndex >= WaypointsController.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WaypointsController.points[wavepointIndex];
    }
}

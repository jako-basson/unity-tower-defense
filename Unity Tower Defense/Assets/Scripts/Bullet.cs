using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 70f;

    private Transform _target;
    public GameObject impactEffect;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

	void Update () {
        if (_target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = _target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget() {
        var effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(gameObject);
        Destroy(_target.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Projectile projectilePrefab;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if(mouseButtonDown) {
            raycastOnMouseClick();
        }
    }

    void shoot(RaycastHit hit) {
        var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
        var pointAboveFloor = hit.point + new Vector3(0, this.transform.position.y, 0);
        var direction = pointAboveFloor - transform.position;
        var shootRay = new Ray(this.transform.position, direction);
        //Debug.DrawRay(shootRay.origin, shootRay.direction * 100.1f, Color.red, 2); //Debug ray for bullet trajectory

        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());
        projectile.FireProjectile(shootRay);
    }

    void raycastOnMouseClick() {
        RaycastHit hit;
        Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(rayToFloor.origin, rayToFloor.direction * 100.1f, Color.red, 2); //debug ray from mouse

        if(Physics.Raycast(rayToFloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide)) {
            shoot(hit);
        }
    }

}

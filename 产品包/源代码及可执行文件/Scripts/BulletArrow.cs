using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Arrow fly trajectory.
/// </summary>
public class BulletArrow : MonoBehaviour
{
    public GameObject boom = null;
    public bool IfBoom;
    // Damage amount
    public float damage;
    public GameObject Enemy;
    // Starting speed
    public float speed = 3f;
    // Constant acceleration
    public float speedUpOverTime = 0.5f;
    // If target is close than this distance - it will be hitted
    public float hitDistance = 0.2f;

    // From this position bullet was fired
    private Vector2 originPoint;
    // Last target's position
    private Vector2 aimPoint;
    // Current position without ballistic offset
    private Vector2 myVirtualPosition;
    // Position on last frame
    private Vector2 myPreviousPosition;
    // Counter for acceleration calculation
    private float counter;


    public void SetTarget(GameObject enemy)
    {
        Enemy = enemy;
    }

    void Start() {
        originPoint = myVirtualPosition = myPreviousPosition = transform.position;
    }

    void FixedUpdate()
    {
        if(Enemy == null)
            Destroy(gameObject);

        counter += Time.fixedDeltaTime;
        // Add acceleration
        speed += Time.fixedDeltaTime * speedUpOverTime;
        if (Enemy != null)
        {
            aimPoint = Enemy.transform.position;
          
        }
        // Calculate distance from firepoint to aim
        Vector2 originDistance = aimPoint - originPoint;
        // Calculate remaining distance
        Vector2 distanceToAim = aimPoint - (Vector2)myVirtualPosition;
        // Add ballistic offset to trajectory
       // Debug.Log(myVirtualPosition);
        transform.position = myVirtualPosition;
        // Rotate bullet towards trajectory
        LookAtDirection2D((Vector2)transform.position - myPreviousPosition);
        myPreviousPosition = transform.position;
        // Close enough to hit
        if (distanceToAim.magnitude <= hitDistance)
        {
            if (Enemy != null)
            {
                //怪物扣血
                Enemy.GetComponent<Moster>().HP -= damage;
                if (this.gameObject.tag == "Fire")
                    Enemy.GetComponent<Moster>().iffired = true;
                if (this.gameObject.tag == "Lighting")
                    Enemy.GetComponent<Moster>().ifslow = true;//是否减速

                //删除
                Destroy(this.gameObject);
                if (IfBoom)
                {
                    Vector2 boomposition = Enemy.transform.position;
                    Instantiate(boom, boomposition, Quaternion.identity);
                }
            }
        }
        else
        {
            if (Enemy != null)
            {
                // Move towards aim
                myVirtualPosition = Vector2.Lerp(originPoint , aimPoint, counter * speed / originDistance.magnitude);
               // Debug.Log("改变了吗");
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    /// <summary>
    /// Looks at direction2d.
    /// </summary>
    /// <param name="direction">Direction.</param>
    private void LookAtDirection2D(Vector2 direction)
    {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


}

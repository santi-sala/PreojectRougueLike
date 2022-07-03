using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Regular : Bullet
{
    private Rigidbody2D _rigidbody2D;
    private bool _isDead = false;

    public override SO_BulletData BulletData 
    { 
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D != null && BulletData != null)
        {
            _rigidbody2D.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead)
        {
            return;
        }
        _isDead = true;

        var hittable = collision.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, gameObject);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(collision);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(collision);
        }
        Destroy(gameObject);
    }

    private void HitEnemy(Collider2D collision)
    {
        var knockedBack = collision.GetComponent<IKnockedBack>();
        knockedBack?.KnockedBack(transform.right, BulletData.KnockBackPower, BulletData.KnockBackDelay);
        Vector2 randomOffset = Random.insideUnitCircle * 0.5f;
        Instantiate(BulletData.ImpactEnemyPrefab, collision.transform.position + (Vector3)randomOffset, Quaternion.identity);
    }

    private void HitObstacle(Collider2D collision)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

        if (hit.collider != null)
        {
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
        }
    }
}

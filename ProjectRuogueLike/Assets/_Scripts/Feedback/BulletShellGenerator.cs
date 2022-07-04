using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShellGenerator : ObjectPool
{
    [SerializeField]
    private float _flyDuration = 0.3f;
    [SerializeField]
    private float _flyStrenght = 1;

    public void SpawnBulletShell()
    {
        var shell = SpawnObject();
        MoveShellRandomDirection(shell); 
    }

    private void MoveShellRandomDirection(GameObject shell)
    {
        shell.transform.DOComplete();
        var randomDirection = UnityEngine.Random.insideUnitCircle;
        randomDirection = randomDirection.y > 0 ? new Vector2 (randomDirection.x, -randomDirection.y) : randomDirection;
        shell.transform.DOMove(((Vector2)transform.position + randomDirection) * _flyStrenght, _flyDuration).OnComplete(() => shell.GetComponent<AudioSource>().Play());
        shell.transform.DORotate(new Vector3(0, 0, UnityEngine.Random.Range(0f, 360f)), _flyDuration);

    }
}

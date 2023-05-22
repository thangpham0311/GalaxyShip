using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject SpacePrefab;
    [SerializeField] protected GameObject SpaceSpawnPos;

    [SerializeField] protected GameObject SpaceCurrent;

    protected float distance = 0f;

    private void Awake()
    {
        SpacePrefab = GameObject.Find("SpacePrefab");
        SpaceSpawnPos = GameObject.Find("SpaceSpawPos");

        this.SpacePrefab.SetActive(false);

        this.SpaceCurrent = this.SpacePrefab;

        this.Spawn(this.SpacePrefab.transform.position);
    }

    private void FixedUpdate()
    {
        this.UpdateRoad();
    }

    protected virtual void UpdateRoad()
    {
        this.distance = Vector2.Distance(PlayerCtrl.Instance.transform.position, this.SpaceCurrent.transform.position);
        if (this.distance > 23) this.Spawn();
    }

    protected virtual void Spawn()
    {
        Vector3 pos = this.SpaceSpawnPos.transform.position;
        pos.y = 0;
        this.Spawn(pos);
    }

    protected virtual void Spawn(Vector3 position)
    {
        this.SpaceCurrent = Instantiate(this.SpacePrefab, position, this.SpacePrefab.transform.rotation);
        this.SpaceCurrent.transform.parent = transform;
        this.SpaceCurrent.SetActive(true);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseEnemy : StateEnemy
{
    [SerializeField] List<Transform> barrelPositions;
    [SerializeField] float timeMaxTime;
    float time;
    Vector3 nextPos;
    Vector3 startPos;
    int transformIndex;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }
    public void SetObstaclesList(List<Transform> obstacles)
    {
        barrelPositions = obstacles;
        transformIndex = UnityEngine.Random.Range(0, barrelPositions.Count);
        startPos = transform.position;
        nextPos = new Vector3(barrelPositions[transformIndex].position.x,
                              barrelPositions[transformIndex].position.y,
                              transform.position.z);
    }
    protected override IEnumerator Choice()
    {
        choising = true;
        yield return new WaitForSeconds(choisingTime);

        switch(Random.Range(0,101))
        {
            case int n when n >= probToShoot:
                state = State.move;
                break;
            case int n when n < probToShoot:
                state = State.uncover;
                break;
        }
        choising = false;
    }
    
    
    protected override void Move()
    {
        if (time < 1 && startPos != nextPos)
        {
            time += Time.deltaTime / timeMaxTime;
        }
        else
        {
            startPos = nextPos;
            Vector3 aux;
            do
            {
                transformIndex = UnityEngine.Random.Range(0, barrelPositions.Count);
                aux = new Vector3(barrelPositions[transformIndex].position.x,
                                  barrelPositions[transformIndex].position.y,
                              transform.position.z);
            } while (aux == nextPos);
            nextPos = aux;
            time = 0;
            state = State.choice;
        }
        transform.position = Vector3.Lerp(startPos, new Vector3(nextPos.x, nextPos.y, transform.position.z), time);
    }
    protected override void Uncover()
    {

        state = State.shoot;
    }
    protected override void Shoot()
    {

        state = State.Cover;
    }
    protected override void Cover()
    {

        state = State.choice;
    }
}

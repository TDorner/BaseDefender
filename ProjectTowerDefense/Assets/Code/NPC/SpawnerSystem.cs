using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class SpawnerSystem : ComponentSystem
{
    private int spawner;
    private Unity.Mathematics.Random random;

    /*protected override void OnCreate()
    {
        // Connection zu IComponentData fetchen
        spawner = EntityManager.GetComponentData<EntityTest>(EntityManager.).spawnNumber;
        spawner = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EntityTest>().spawnNumber;
        random = new Unity.Mathematics.Random(10);

        int n = 0;
        while (n < spawner)
        {
            Debug.Log(n);
            n++;

            Entities.ForEach((ref EntityTest eTest) =>
            {
                Entity spawnedEntity = EntityManager.Instantiate(eTest.entity);
                EntityManager.SetComponentData(spawnedEntity,
                    new Translation { Value = new float3(random.NextFloat(0, 10f), 0, random.NextFloat(0, 10f)) }
                    );
            });
        }
    }*/

    protected override void OnUpdate()
    {
        //Debug.Log("Do Job");
    }

}

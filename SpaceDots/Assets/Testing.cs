using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        var entityArchetype = entityManager.CreateArchetype(
            // typeof(LevelComponent),
            typeof(Translation),
            // typeof(RenderMesh),
            typeof(LocalToWorld)
            // typeof(RenderBounds)
        );
        var entityArray = new NativeArray<Entity>(1, Allocator.Temp);

        entityManager.CreateEntity(entityArchetype, entityArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

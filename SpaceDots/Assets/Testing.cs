using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts
{
    public class Testing : MonoBehaviour
    {
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;

        private void Start()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            var entityArchetype = entityManager.CreateArchetype(
                typeof(Translation),
                typeof(Rotation),
                typeof(AsteroidMoveComponent),
                typeof(RenderMesh),
                typeof(LocalToWorld),
                typeof(RenderBounds)
            );
            var entityArray = new NativeArray<Entity>(10000, Allocator.Temp);

            entityManager.CreateEntity(entityArchetype, entityArray);

            for (var i = 0; i < entityArray.Length; i++)
            {
                var entity = entityArray[i];

                entityManager.SetComponentData(entity, new Translation { Value = new float3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100)) });
                entityManager.SetComponentData(entity, new Rotation { Value = math.mul(quaternion.identity, quaternion.RotateX(UnityEngine.Random.Range(-180, 180))) });
                entityManager.SetComponentData(entity, new AsteroidMoveComponent { RotationSpeed = UnityEngine.Random.Range(-0.5f, 0.5f) });
                entityManager.SetSharedComponentData(entity, new RenderMesh
                {
                    mesh = _mesh,
                    material = _material
                });
            }


            entityArray.Dispose();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts
{
    public class AsteroidsRotateSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref Rotation rotation, ref AsteroidMoveComponent asteroidMoveComponent) =>
            {
                rotation.Value = math.mul(rotation.Value, quaternion.RotateX(asteroidMoveComponent.RotationSpeed * Time.DeltaTime));
            });
        }
    }

}
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts
{
    [BurstCompile]
    public class AsteroidsRotateSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref Rotation rotation, ref AsteroidMoveComponent asteroidMoveComponent) =>
            {
                rotation.Value = Quaternion.AngleAxis(asteroidMoveComponent.RotationSpeed * (float)Time.ElapsedTime * 100, new Vector3(asteroidMoveComponent.RotationSpeed, asteroidMoveComponent.RotationSpeed, asteroidMoveComponent.RotationSpeed));
            });
        }
    }

}
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts
{
    public struct AsteroidMoveComponent : IComponentData
    {
        public float RotationSpeed;
    }

}
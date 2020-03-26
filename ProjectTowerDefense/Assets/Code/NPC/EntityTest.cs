using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct EntityTest : IComponentData
{
    public Entity entity;
    public int spawnNumber;
}

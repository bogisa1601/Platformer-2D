using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameplayEvents 
{
    public static event Action<BaseCollectable> OnAddCollectable;

    public static void RaiseOnAddCollectable(BaseCollectable collectable) => OnAddCollectable?.Invoke(collectable);

}

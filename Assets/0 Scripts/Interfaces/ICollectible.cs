using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectible
{
   void GetCollected();
}

public interface IObstacle
{
   void Hit(Transform other);
}

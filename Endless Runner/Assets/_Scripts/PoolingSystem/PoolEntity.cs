using System;
using UnityEngine;

namespace TheCreators.PoolingSystem
{
    public class PoolEntity : MonoBehaviour, IPoolable<PoolEntity>
    {
        private Action<PoolEntity> returnToPool;

        private void OnDisable()
        {
            ReturnToPool();
        }

        public void Initialize(Action<PoolEntity> returnAction)
        {
            //cache reference to return action
            this.returnToPool = returnAction;
        }

        public void ReturnToPool()
        {
            //invoke and return this object to pool
            returnToPool?.Invoke(this);
        }
    }
}
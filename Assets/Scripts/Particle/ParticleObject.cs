using System;
using Pool;
using UnityEngine;

namespace Particle
{
    public class ParticleObject : PoolObject<ParticleObject>
    {
        [SerializeField] private ParticleSystem particle;

        public override void OnGetAfter()
        { 
            particle.Play();
        }

        private void Update()
        {
            if (!particle.isPlaying)
            {
                Release();
            }
        }
    }
}
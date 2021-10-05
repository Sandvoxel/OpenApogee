using JetBrains.Annotations;

namespace OpenApogee.Models.Physics {
    public class SimplePhysicsSim {
        private Vector3 position = new Vector3();
        private Vector3 momentum = new Vector3();
        
        private Vector3 velocity = new Vector3();

        private float mass = 2;
        private float inverseMass = 1;

        public SimplePhysicsSim(Vector3 momentum) {
            this.momentum = momentum;
        }
        
        public void Update() {
            velocity = momentum / mass;
        }
        
        public Vector3 Position => position;
        public Vector3 Velocity => velocity;

    }
}
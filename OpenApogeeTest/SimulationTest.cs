using System;
using NUnit.Framework;
using OpenApogee.Models;
using OpenApogee.Models.Physics;

namespace OpenApogeeTest {
    public class Tests {
        private RocketObject _rocketObject;
        private readonly Random _random = new();
        [SetUp]
        public void Setup() {
            _rocketObject = new(1, 15, 2, 0.001);
        }

        [Test]
        public void CheckSimulationRerunStatus() {
            Assert.IsTrue(_rocketObject.Simulate());
            Assert.IsFalse(_rocketObject.Simulate());
            Assert.IsTrue(_rocketObject.Simulate(true));
        }
        [Test]
        public void CheckSimulationAccuracy() {
            RocketObject rocketObject;

            double mass;
            double thrust;
            double burnTime;

            for (int i = 0; i < 100; i++) {
                mass = randomFromRange(0.5, 2);
                thrust = randomFromRange(15, 50);
                burnTime = randomFromRange(1, 5);

                double heightAtBurnout = 0.5 * (thrust + Constants.GRAVITY * mass) / mass * (burnTime * burnTime);
                double velocityAtBurnout = (thrust + Constants.GRAVITY * mass) / mass * burnTime;
                double apogee = (velocityAtBurnout * velocityAtBurnout) / -(2 * Constants.GRAVITY) + heightAtBurnout;
                if (apogee < 1) continue;

                rocketObject = new(mass, thrust, burnTime);
                rocketObject.Simulate();

                double error = (rocketObject.Apogee - apogee) / apogee * 100;

                Console.WriteLine(apogee + " " + rocketObject.Apogee);
                Console.WriteLine(error);
                Console.WriteLine("");

                if (error > 1) Assert.Fail("Simulation has excessive error");

            }
        }

        private double randomFromRange(double min, double max) {
            return _random.NextDouble() * (max - min) + min;
        }
    }
}



















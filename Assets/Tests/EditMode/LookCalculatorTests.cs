using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class LookCalculatorTests
    {
        public class HasLookInputTests
        {
            [Test]
            public void LookCalculator_HasLookInput_Returns_True_When_Y_Above_0()
            {
                var lookCalculator = new LookCalculator();

                var hasLookInput = lookCalculator.HasLookInput(Vector2.down);
                
                Assert.IsTrue(hasLookInput);
            }
            [Test]
            public void LookCalculator_HasLookInput_Returns_False_When_Y_Is_0()
            {
                var lookCalculator = new LookCalculator();

                var hasLookInput = lookCalculator.HasLookInput(Vector2.zero);
                
                Assert.IsFalse(hasLookInput);
            }
        }

        public class HasTurnInputTests
        {
            [Test]
            public void LookCalculator_HasTurnInput_Returns_True_When_X_Above_0()
            {
                var lookCalculator = new LookCalculator();

                var hasTurnInput = lookCalculator.HasTurnInput(Vector2.right);
                
                Assert.IsTrue(hasTurnInput);
            }
            [Test]
            public void LookCalculator_HasTurnInput_Returns_False_When_X_Is_0()
            {
                var lookCalculator = new LookCalculator();

                var hasTurnInput = lookCalculator.HasTurnInput(Vector2.zero);
                
                Assert.IsFalse(hasTurnInput);
            }
        }

        public class GetNewLookAngleTests
        {
            [Test]
            public void LookCalculator_GetNewLookAngle_Returns_Minimum_Of_Neg_45_When_Looking_Up()
            {
                var lookCalculator = new LookCalculator(); 

                var newAngle = lookCalculator.GetNewLookAngle(Vector2.up.y, -45, 10, 0.1f);
                
                Assert.AreEqual(-45, newAngle);
            }

            [Test]
            public void LookCalculator_GetNewLookAngle_Returns_Maximum_Of_45_When_Looking_Down()
            {
                var lookCalculator = new LookCalculator(); 

                var newAngle = lookCalculator.GetNewLookAngle(Vector2.down.y, 45, 10, 0.1f);
                
                Assert.AreEqual(45, newAngle);
            }

            [Test]
            public void LookCalculator_GetNewLookAngle_Returns_Angle_Increased_By_Speed()
            {
                var lookCalculator = new LookCalculator(); 

                var newAngle = lookCalculator.GetNewLookAngle(Vector2.down.y, 0, 10, 1.0f);
                
                Assert.AreEqual(10, newAngle);
            }
        }

        public class GetNewLookRotationTests
        {
            [Test]
            public void LookCalculator_GetNewLookRotation_Has_0_For_Y_And_Z()
            {
                var lookCalculator = new LookCalculator();

                var lookRotation = lookCalculator.GetNewLookRotation(20);
                
                Assert.AreEqual(new Vector3(20, 0,0), lookRotation);
            }
            [Test]
            public void LookCalculator_GetNewLookRotation_Returns_Rotation_With_Angle_As_X()
            {
                var lookCalculator = new LookCalculator();

                var lookRotation = lookCalculator.GetNewLookRotation(20);
                
                Assert.AreEqual(20, lookRotation.x);
            }
        }
    }
}

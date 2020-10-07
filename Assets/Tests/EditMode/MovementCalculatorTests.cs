using NUnit.Framework;
using UnityEngine;
using ZombieGame.Player;

namespace Tests
{
    public class MovementCalculatorTests
    {
        public class NewVelocityTests
        {
            [Test]
            public void MovementCalculator_NewVelocity_Returns_With_Current_Fall_Speed()
            {
                var testPlayer = new GameObject();
                var movementCalculator = new MovementCalculator();

                var newVelocity = movementCalculator.CalculateNewVelocity(
                    testPlayer.transform, new Vector3(10, 10, 10), Vector2.up, 6, 4);

                Assert.AreEqual(10, newVelocity.y);
            }

            [Test]
            public void MovementCalculator_NewVelocity_Up_Input_Returns_Forward_Direction()
            {
                var testPlayer = new GameObject();
                var movementCalculator = new MovementCalculator();

                var newVelocity = movementCalculator.CalculateNewVelocity(
                    testPlayer.transform, new Vector3(10, 10, 10), Vector2.up, 6, 4);

                Assert.AreEqual(6, newVelocity.z);
            }

            [Test]
            public void MovementCalculator_NewVelocity_Down_Input_Returns_Back_Direction()
            {
                var testPlayer = new GameObject();
                var movementCalculator = new MovementCalculator();
                var newVelocity = movementCalculator.CalculateNewVelocity(
                    testPlayer.transform, new Vector3(10, 10, 10), Vector2.down, 6, 4);

                Assert.AreEqual(-6, newVelocity.z);
            }

            [Test]
            public void MovementCalculator_NewVelocity_Forward_Velocity_Increased_By_ForwardSpeed()
            {
                var testPlayer = new GameObject();
                var movementCalculator = new MovementCalculator();
                var newVelocity = movementCalculator.CalculateNewVelocity(
                    testPlayer.transform, new Vector3(10, 10, 10), Vector2.up, 6, 4);

                Assert.AreEqual(6, newVelocity.z);
            }

            [Test]
            public void MovementCalculator_NewVelocity_Right_Input_Returns_Right_Direction()
            {
                var testPlayer = new GameObject();
                var movementCalculator = new MovementCalculator();

                var newVelocity = movementCalculator.CalculateNewVelocity(
                    testPlayer.transform, new Vector3(10, 10, 10), Vector2.right, 6, 4);

                Assert.AreEqual(4, newVelocity.x);
            }

            [Test]
            public void MovementCalculator_NewVelocity_Left_Input_Returns_Left_Direction()
            {
                var testPlayer = new GameObject();
                var movementCalculator = new MovementCalculator();

                var newVelocity = movementCalculator.CalculateNewVelocity(
                    testPlayer.transform, new Vector3(10, 10, 10), Vector2.left, 6, 4);

                Assert.AreEqual(-4, newVelocity.x);
            }

            [Test]
            public void MovementCalculator_NewVelocity_Side_Velocity_Increased_By_SideSpeed()
            {
                var testPlayer = new GameObject();
                var movementCalculator = new MovementCalculator();
                var newVelocity = movementCalculator.CalculateNewVelocity(
                    testPlayer.transform, new Vector3(10, 10, 10), Vector2.right, 6, 4);

                Assert.AreEqual(4, newVelocity.x);
            }
        }

        public class IsMovingTests
        {
            [Test]
            public void MovementCalculator_IsMoving_Returns_True_When_Velocity_Is_Non_Zero()
            {
                var movementCalculator = new MovementCalculator();

                var isMoving = movementCalculator.IsMoving(Vector3.forward);

                Assert.AreEqual(true, isMoving);
            }

            [Test]
            public void MovementCalculator_IsMoving_Returns_False_When_Velocity_Is_Zero()
            {
                var movementCalculator = new MovementCalculator();

                var isMoving = movementCalculator.IsMoving(Vector3.zero);

                Assert.AreEqual(false, isMoving);
            }
        }

        public class HasMovementInputTests
        {
            [Test]
            public void MovementCalculator_HasMovementInput_Returns_True_When_X_Has_Input()
            {
                var movementCalculator = new MovementCalculator();

                var hasMovementInput = movementCalculator.HasMovementInput(Vector2.right);
                
                Assert.AreEqual(true, hasMovementInput);
            }
            [Test]
            public void MovementCalculator_HasMovementInput_Returns_True_When_Y_Has_Input()
            {
                var movementCalculator = new MovementCalculator();

                var hasMovementInput = movementCalculator.HasMovementInput(Vector2.up);
                
                Assert.AreEqual(true, hasMovementInput);
            }

            [Test]
            public void MovementCalculator_HasMovementInput_Returns_False_When_No_Input()
            {
                var movementCalculator = new MovementCalculator();

                var hasMovementInput = movementCalculator.HasMovementInput(Vector2.zero);
                
                Assert.AreEqual(false, hasMovementInput);
            }
        }
    }
}

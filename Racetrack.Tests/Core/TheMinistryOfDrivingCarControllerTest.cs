using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Racetrack.Core
{
    [TestFixture]
    public class TheMinistryOfDrivingCarControllerTest
    {
        private TheMinistryOfDrivingCarController _target;

        private PoopyMacgoopyTrack _track;

        private readonly Line VerticalStartLine = new Line(1, 1, 1, 2);
        private readonly Line HorizontalStartLine = new Line(1, 1, 2, 1);
        private SpeedRacerCar _car;

        [SetUp]
        public void Setup()
        {
            _car = new SpeedRacerCar();
            _track = new PoopyMacgoopyTrack();
            _target = new TheMinistryOfDrivingCarController(_track, _car);
        }

        [Test]
        public void WhenFinishIsLineGoingPositiveXCarIncreasesXVelocity()
        {
            _track.WithStartingLineAtPoints(VerticalStartLine)
                .WithCarsDriving(DrivingDirection.Right);
            _track.Add(_car);

            _target.BrainWashCar();

            AssertCarVelocityIs(1, 0);
        }

        [Test]
        public void WhenFinishLineIsGoingNegativeXCarDecreasesXVelocity()
        {
            _track.WithStartingLineAtPoints(VerticalStartLine)
                .WithCarsDriving(DrivingDirection.Left);
            _track.Add(_car);

            _target.BrainWashCar();

            AssertCarVelocityIs(-1, 0);
        }

        [Test]
        public void WhenFinishLineIsGoingPositiveYCarIncreasesYVelocity()
        {
            _track.WithStartingLineAtPoints(HorizontalStartLine)
                .WithCarsDriving(DrivingDirection.Up);
            _track.Add(_car);

            _target.BrainWashCar();

            AssertCarVelocityIs(0, 1);
        }

        [Test]
        public void WhenFinishLineIsGoingNegativeYCarDecreasesYVelocity()
        {
            _track.WithStartingLineAtPoints(HorizontalStartLine)
                .WithCarsDriving(DrivingDirection.Down);
            _track.Add(_car);

            _target.BrainWashCar();

            AssertCarVelocityIs(0, -1);
        }

        [Test]
        public void WhenApproachingWallGoingRightCarDecreasesXVelocity()
        {
            _track.WithCarsDriving(DrivingDirection.Right);
            _track.AddWall(2, 0);
            _track.Add(_car);
            _car.VelocityX = 2;

            _target.BrainWashCar();

            _car.VelocityX.Should().Be(1, "because the car needs to not drive so fast to the right");
        }

        [Test]
        public void WhenApproachingWallGoingLeftCarDecreasesXVelocity()
        {

            _track.WithStartingLineAtPoints(2,0,2,1).WithCarsDriving(DrivingDirection.Left);
            _track.AddWall(0, 0);
            _track.Add(_car);
            _car.VelocityX = -2;

            _target.BrainWashCar();

            _car.VelocityX.Should().Be(-1, "because the car needs to not drive so fast to the left");
        }
        private void AssertCarVelocityIs(int xVelocity, int yVelocity)
        {
            var message = "";
            if (_car.VelocityX != xVelocity) message += string.Format("Expected Car's X Velocity to be {0} but found {1}\r\n", xVelocity, _car.VelocityX);
            if (_car.VelocityY != yVelocity) message += string.Format("Expected Car's Y Velocity to be {0} but found {1}\r\n", yVelocity, _car.VelocityY);

            if (!string.IsNullOrEmpty(message))
                throw new System.Exception(message);
        }
    }
}

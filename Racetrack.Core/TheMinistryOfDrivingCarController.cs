using System.Linq;

namespace Racetrack.Core
{
    public class TheMinistryOfDrivingCarController
    {
        private readonly PoopyMacgoopyTrack _track;
        private readonly SpeedRacerCar _car;
        public TheMinistryOfDrivingCarController(PoopyMacgoopyTrack track, SpeedRacerCar car)
        {
            _track = track;
            _car = car;
        }

        public void BrainWashCar()
        {
            switch (_track.Direction)
            {
                case DrivingDirection.Up:
                    ++_car.VelocityY;
                    break;
                case DrivingDirection.Down:
                    --_car.VelocityY;
                    break;
                case DrivingDirection.Left:
                    _car.VelocityX -= GetVelocityModifier();
                    break;
                case DrivingDirection.Right:
                    _car.VelocityX += GetVelocityModifier();
                    break;
            }
        }
        private int GetVelocityModifier()
        {
            if (ShouldSlowDown()) return -1;

            return 1;
        }
        private bool ShouldSlowDown()
        {
            var impactDistance = Enumerable.Range(_car.CurrentPosition.X, _car.VelocityX + 1);

            if (_track.Walls.Where(wall=>wall.Y == _car.CurrentPosition.Y).Select(wall=>wall.X).Intersect(impactDistance).Any())
                return true;

            return false;
        }
    }
}

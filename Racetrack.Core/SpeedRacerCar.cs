namespace Racetrack.Core
{
    public class SpeedRacerCar
    {
        public Point CurrentPosition { get; private set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }

        internal void Accept(Point point1)
        {
            CurrentPosition = point1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrack.Core
{
    public class PoopyMacgoopyTrack
    {
        public DrivingDirection Direction { get; private set; }
        public Line StartingLine { get; private set; }
        public ICollection<Point> Walls { get; private set; }

        public PoopyMacgoopyTrack()
        {
            Direction = new DrivingDirection();
            Walls = new List<Point>();
            WithStartingLineAtPoints(0, 0, 0, 0);
        }
        public void Add(SpeedRacerCar car)
        {
            car.Accept(StartingLine.Point1);
        }

        public void AddWall(int x, int y)
        {
            Walls.Add(new Point(x, y));
        }

        public PoopyMacgoopyTrack WithStartingLineAtPoints(Line line)
        {
            StartingLine = line;
            return this;
        }
        public PoopyMacgoopyTrack WithStartingLineAtPoints(int x1, int y1, int x2, int y2)
        {
            return WithStartingLineAtPoints(new Line(new Point(x1, y1), new Point(x2, y2)));
        }

        public PoopyMacgoopyTrack WithCarsDriving(DrivingDirection drivingDirection)
        {
            Direction = drivingDirection;
            return this;
        }
    }
}

namespace Racetrack.Core
{
    public class Line
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }
        public Line(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public Line(int x1, int y1, int x2, int y2)
        {
            Point1 = new Point(x1, y1);
            Point2 = new Point(x2, y2);
        }
    }
}
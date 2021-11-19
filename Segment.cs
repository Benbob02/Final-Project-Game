using System;

namespace Final_Project
{
    /// <summary>
    /// Represents a square in the snakes body.
    /// </summary>
    class Segment : Actor
    {
        
        public Segment(Point position, Point velocity)
        {
            _position = position;
            _velocity = velocity;
        }
        
    }

}
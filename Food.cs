using System;

namespace Final_Project
{
    public class Food : Actor
    {
        private int _food;
        
        public Food()
        {
            Random rnd = new Random();
            _position = new Point(rnd.Next(0,600),rnd.Next(0,400));
            _velocity = new Point(rnd.Next(0,600),rnd.Next(0,400));
            _food = 5;
        }
        public int GetPoints()
        {
            return _food;
        }
        public void Reset()
        {
            MoveNext();
        }
    }
 
}
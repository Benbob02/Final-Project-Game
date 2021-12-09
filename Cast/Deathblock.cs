using System;

namespace Final_Project
{
    public class Deathblock : Actor
    {
 
        public Deathblock()
        {
            Random rnd = new Random();
            _position = new Point(rnd.Next(0,Constants.MAX_X - 20),rnd.Next(0,Constants.MAX_Y - 20));
            _velocity = new Point(0, 0);

        }

        public void Reset()
        {
            Random rnd = new Random();
            _position = new Point(rnd.Next(0,Constants.MAX_X - 20),rnd.Next(0,Constants.MAX_Y - 20));
        }

        public override void AddPoints(int points)
        {
            points += 1;
        }


    }
 
}
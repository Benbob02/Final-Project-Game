using System;

namespace Final_Project
{
    public class Letter : Actor
    {

        private string _letter;
        
        public Letter(char letter)
        {
            Random rnd = new Random();
            _position = new Point(rnd.Next(0,Constants.MAX_X - 20),rnd.Next(0,Constants.MAX_Y - 20));
            _velocity = new Point(0, 0);
            _letter = letter.ToString();
        }

        public void Reset()
        {
            Random rnd = new Random();
            _position = new Point(rnd.Next(0,Constants.MAX_X - 20),rnd.Next(0,Constants.MAX_Y - 20));
        }
        public string GetLetter()
        {
            return _letter;
        }

        public override void AddPoints(int points)
        {
            points += 1;
        }
    }
 
}
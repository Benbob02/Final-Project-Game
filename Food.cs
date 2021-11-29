using System;

namespace Final_Project
{
    public class Food : Actor
    {
        private int _food;
        private string _letter;
        
        public Food(char letter)
        {
            Random rnd = new Random();
            _position = new Point(rnd.Next(0,Constants.MAX_X - 20),rnd.Next(0,Constants.MAX_Y - 20));
            _velocity = new Point(0, 0);
            _food = 5;
            _letter = letter.ToString();
        }
        public int GetPoints()
        {
            return _food;
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
    }
 
}
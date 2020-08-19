using System;

namespace DemoMultiCategories.Models.Client.Data
{
    public class Movie
    {
        private int _id, _year;
        private string _title;        

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }

            set
            {
                _year = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public Movie(string title, int year)
        {
            Year = year;
            Title = title;
        }

        internal Movie(int id, string title, int year)
            : this (title, year)
        {
            Id = id;
        }
    }
}

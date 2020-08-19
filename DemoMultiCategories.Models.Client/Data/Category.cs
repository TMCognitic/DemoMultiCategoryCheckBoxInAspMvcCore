using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMultiCategories.Models.Client.Data
{
    public class Category
    {
        private int _id;
        private string _name;

        public int Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public Category(string name)
        {
            Name = name;
        }

        internal Category(int id, string name)
            : this (name)
        {
            Id = id;
        }
    }
}

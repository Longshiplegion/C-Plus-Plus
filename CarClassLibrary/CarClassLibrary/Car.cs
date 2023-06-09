using System;
using System.Collections.Generic;
using System.Text;

namespace CarClassLibrary
{
    public class Car
    {
        public string Make { get; set; }
        public String Model { get; set; }
        public decimal Price { get; set; }
        public int Miles { get; set; }
        public int Year { get; set; }


        public Car(string make,string model,decimal price,int miles,int year)
        {
            Make = make;
            Model = model;
            Price = price;
            Miles = miles;
            Year = year;

        }

        public Car()
        {
            Make = "Nothing Yet";
            Model = "Nothing Yet";
            Price = 0;
            Miles = 0;
            Year = 0;
        }
        public string Display
        {
            get
            {
                return string.Format("{0} {1} ${2} {3} {4}", Make, Model, Price, Miles, Year);

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShop.V1.Models;

namespace WorkShop.V1
{
    public static class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie()
            {
                Title="Terminator",
                Description="Humans vs Terminator",
                Year=1986,
                Genre="Action"
            },
            new Movie()
            {
                Title="Terminator 2",
                Description="Terminator",
                Year=1991,
                Genre="Scifi"
            },
            new Movie()
            {
                Title="Terminator 3",
                Description="Terminator vs Soldiers",
                Year=2003,
                Genre="Horor"
            },

        };
    }
}

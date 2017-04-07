using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoodleTypes.Models
{
    public class DoodleHabit
    {
        public int DoodleHabitID { get; set; }
        public string Description { get; set; }

        public int DoodleBreedID { get; set; }
        public virtual DoodleBreed Doodling { get; set; }
    }
}
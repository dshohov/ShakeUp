﻿using ShakeUp.Data.Enum;

namespace ShakeUp.ViewModels
{
    public class AlcoholVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DrinkStrength Type { get; set; }

        public double Degree { get; set; }

        public byte[] Photo { get; set; }

        public string BackgroundColor { get; set; }

    }
}

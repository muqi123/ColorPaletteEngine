using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Data
{
    public class ColorExtractionModel
    {
        public string ImageBase64
        {
            get => Image == null ? null : Convert.ToBase64String(Image);
            set => Image = value == null ? null : Convert.FromBase64String(value);
        }

        [Required]
        public float accentAndTBContrastThreshold { get; set; } = 2;

        [Required]
        public float tbContrastThreshold { get; set; } = 4.5F;

        [Required]
        public float hlAndFhlContrastThreshold { get; set; } = 3;

        public byte[] Image { get; set; }
    }
}

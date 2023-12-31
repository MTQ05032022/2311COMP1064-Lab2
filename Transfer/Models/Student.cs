﻿using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Transfer.Models
{
    public class Student
    {
        [Display(Name ="Mã sinh viên")]
        public string StudentId { get; set; }

        [Display(Name = "Họ và tên sinh viên")]
        public string StudentName { get; set; }

        [Display(Name = "Điểm")]
        public double Mark { get; set;}

        [Display(Name = "Nam")]
        public bool IsMale 
        {
            get; 
            set;
        }

        [Display(Name = "Học lực")]
        public string? Grade
        {
            get
            {
                if (Mark >= 8.5) return "A";
                if (Mark >= 7.8) return "B+";
                if (Mark >= 7) return "B";
                if (Mark >= 5) return "C";
                return "D";

            }
            
        }
    
    }
}

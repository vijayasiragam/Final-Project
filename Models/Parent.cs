using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Parent
    {
        [Key]
        public int FamilyId { get; set; }
        [Required]
        public string ParentName { get; set; }
        [Required]
        public string ChildFirstName { get; set; }
        [Required]
        public string ChildLastName { get; set; }
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public string TeacherName { get; set; }
        
        public string SchoolName { get; set; }
        public PAdmin PAdmin { get; set; }
        
    }
}
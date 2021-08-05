using DocControl.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocControl.Application.DTOs
{
    public class DocumentDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "The Code is Required")]
        [Range(1, 999999999999999999)]
        [DisplayName("Code")]
        public int Code { get; set; }
        

        [Required(ErrorMessage = "The Title is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Process is Required")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Process")]
        public string Process { get; set; }

        [Required(ErrorMessage = "The Category is Required")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Category")]
        public string Category { get; set; }


        [Required(ErrorMessage = "The File is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("File")]
        public string File { get; set; }

    }
}

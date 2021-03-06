﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaMarta.Data.Models.Products
{
    public class Products
    {
        [Key]
        public Int64 IDProduct { get; set; }

        [RegularExpression(@"^([.ñÑa-zA-Z0-9]+\s)*[.ñÑa-zA-Z0-9]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 50")]
        public String Name { get; set; }

        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Caracteres especiales no son permitidos")]
        [Required(ErrorMessage = "El Codigo es requerido")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 20")]
        public String Code { get; set; }

        public Boolean State { get; set; }

        [RegularExpression(@"^([.,ñÑa-zA-Z0-9]+\s)*[.,ñÑa-zA-Z0-9]+$", ErrorMessage = "Caracteres no permitidas")]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 70")]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public Decimal Price { get; set; }

        public Decimal? Tax { get; set; }

        public Int64 IdProvider { get; set; }

        [NotMapped]
        public int ConfirmStatus { get; set; }
    }
}

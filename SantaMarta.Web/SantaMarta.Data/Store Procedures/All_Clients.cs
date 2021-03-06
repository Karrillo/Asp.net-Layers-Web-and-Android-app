﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaMarta.Data.Store_Procedures
{
    public class All_Clients
    {
        [Key]
        public Int64 IDPerson { get; set; }

        [RegularExpression(@"^([ñÑa-zA-Z0-9]+\s)*[ñÑa-zA-Z0-9]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 30")]
        public String Name { get; set; }

        [RegularExpression(@"^([ñÑa-zA-Z0-9]+\s)*[ñÑa-zA-Z0-9]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "El primer apellido es requerido")]
        [DataType(DataType.Text)]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 15")]
        public String FirstName { get; set; }

        [RegularExpression(@"^([ñÑa-zA-Z0-9]+\s)*[ñÑa-zA-Z0-9]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "El segundo apellido es requerido")]
        [DataType(DataType.Text)]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 15")]
        public String SecondName { get; set; }

        [EmailAddress(ErrorMessage = "Correo no valido")]
        [DataType(DataType.EmailAddress)]
        [StringLength(40, MinimumLength = 0, ErrorMessage = "El numero de caracteres debe ser menor a 40")]
        [RegularExpression("^[ñÑa-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Correo no valido")]
        public String Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "Numero telefonico no valido")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(9, MinimumLength = 0, ErrorMessage = "El numero de caracteres debe ser menor a 9")]
        public String Phone { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "Numero telefonico no valido")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(9, MinimumLength = 0, ErrorMessage = "El numero de caracteres debe ser menor a 9")]
        public String CellPhone { get; set; }

        [RegularExpression(@"^([.,ñÑa-zA-Z0-9]+\s)*[.,ñÑa-zA-Z0-9]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "La direccion es requerida")]
        [DataType(DataType.Text)]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 70")]
        public String Address { get; set; }

        [RegularExpression(@"^([ñÑa-zA-Z0-9]+\s)*[ñÑa-zA-Z0-9]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "Nombre de compañía es requerida")]
        [DataType(DataType.Text)]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 40")]
        public String NameCompany { get; set; }

        public Int64 IDClient { get; set; }

        [RegularExpression(@"^[^-\s][A-Za-z0-9]*$", ErrorMessage = "Caracteres especiales no son permitidos")]
        [Required(ErrorMessage = "El codigo es requerido")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 30")]
        public String Code { get; set; }

        [NotMapped]
        public Boolean IsProvider { get; set; }

        [NotMapped]
        public int ConfirmStatus { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task2.Models2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Table_2
    {
        public int Id { get; set; }
       // [StringLength(10),]
        public string Account { get; set; }
        public string Amount { get; set; }
        public string Transferto { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }
    }
}

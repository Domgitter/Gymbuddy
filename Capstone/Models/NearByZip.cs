//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capstone.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NearByZip
    {
        public int NearByZipsID { get; set; }
        public int SearchedZip { get; set; }
        public string ZipCode { get; set; }
        public double Distance { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
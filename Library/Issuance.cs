//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library
{
    using System;
    using System.Collections.Generic;
    
    public partial class Issuance
    {
        public int Issuance_ID { get; set; }
        public int Employee_ID { get; set; }
        public int Book_ID { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESeller_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_user
    {
        public int u_id { get; set; }
        [Required(ErrorMessage = "*")]
        public string u_name { get; set; }
        [Required(ErrorMessage = "*")]
        public string u_email { get; set; }
        [Required(ErrorMessage = "*")]
        public string u_password { get; set; }
        [Required(ErrorMessage = "*")]
        public string u_contact { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yapi.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class session_login_throttle
    {
        public string name { get; set; }
        public long attempts { get; set; }
        public long last_attempt { get; set; }
    }
}
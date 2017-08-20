using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yapi.Web.Models
{
    public class SermonSumary
    {
        public long Id { get; set; }

        public string Series { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yapi.Web.Models
{
    public class Series
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public int Sermons { get; set; }
    }
}
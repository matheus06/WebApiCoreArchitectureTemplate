using System;
using System.Collections.Generic;
using System.Text;

namespace MSAP.WebApiCore.Domain.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string Descricao { get; set; }
        public string Serial { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSAP.WebApiCore.Application.ViewModels
{
    public class TodoViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Host { get; set; }
        public string Descricao { get; set; }
        public string Serial { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDev.API.Enums;

namespace PoupaDev.API.Models
{
    public class OperacaoInputModel
    {
        public decimal ValorObjetivo { get; set; }
        public TipoOperacao MyProperty { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena
{
    internal class pagamentos
    {
        public String servico { get; set; }
        public String mes { get; set; }
        public String forma_pagamento { get; set; }
        public String observacao { get; set; }
        public DateTime data_pagamento { get; set; }
        public DateTime data_registo { get; set; }
        public float valor_pagar { get; set; }
        public float valor_entegue { get; set; }
        public float multa { get; set; }
        public float desconto { get; set; }
        public float total { get; set; }
        public float troco { get; set; }
    }
}

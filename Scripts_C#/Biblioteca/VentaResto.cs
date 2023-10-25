using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class VentaResto
    {
        public int mes {get ; set ;}
        public int año {get ; set ;}
        public float monto {get ; set ;}
        public VentaResto(int mes, int año, float monto)
        {
            this.mes = mes;
            this.año = año;
            this.monto = monto;
        }
    }
}
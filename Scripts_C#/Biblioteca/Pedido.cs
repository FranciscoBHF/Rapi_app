using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Pedido
    {
        public int id {get ; set ;}
        public DateTime fecha {get ; set ;}
        public float valoracion {get ; set ;}
        public string descripcion {get ; set ;}
            public Pedido(int id, DateTime fecha, float valoracion, string descripcion)
        {
            this.id = id;
            this.fecha = fecha;
            this.valoracion = valoracion;
            this.descripcion = descripcion;
        } 
    }
}
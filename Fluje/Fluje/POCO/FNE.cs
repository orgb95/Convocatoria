using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluje.POCO
{
    public class FNE
    {
        public int ID { get; set; }
        public float Inversion { set; get; }
        public int Plazo { set; get; }
        public float Tasa { set; get; }
        public float[] Ingresos { set; get; }
        public float[] Egresos { set; get; }
        public float Inflacion { set; get; }
        public float[] Depreciacion1 { set; get; }
        public float[] VS { set; get; }
        public float[] UAI { set; get; }
        public float[] IR { set; get; }
        public float[] UDI { set; get; }
        public float[] Depreciacion2 { set; get; }
        public float[] Fne { set; get; }
    }
}

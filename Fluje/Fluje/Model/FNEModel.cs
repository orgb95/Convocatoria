using Fluje.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluje.Model
{
    public class FNEModel
    {
        int Id = 1;
        private FNE[] flujo;

        public FNEModel() { }

        public void AddElemets(FNE p)
        {
            p.ID = Id;
            if (flujo == null)
            {
                flujo = new FNE[1];
                flujo[0] = p;
                Id++;
                return;
            }
            FNE[] temp = new FNE[flujo.Length + 1];
            Array.Copy(flujo, temp, flujo.Length);
            temp[temp.Length - 1] = p;

            flujo = temp;
            Id++;
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                return;
            }
            if (flujo == null)
            {
                return;
            }
            if (index == 0 && flujo.Length == 1)
            {
                flujo = null;
                return;
            }

            FNE[] temp = new FNE[flujo.Length - 1];
            if (index == 0)
            {
                Array.Copy(flujo, index + 1, temp, 0, temp.Length);
                flujo = temp;
                return;
            }
            if (index == flujo.Length - 1)
            {
                Array.Copy(flujo, 0, temp, 0, temp.Length);
                flujo = temp;
                return;
            }

            if (index == 0)
            {
                Array.Copy(flujo, index + 1, temp, 0, temp.Length);
                flujo = temp;
                return;
            }

            Array.Copy(flujo, 0, temp, 0, index);
            Array.Copy(flujo, index + 1, temp, index, (temp.Length - index));
            flujo = temp;
        }

        public FNE[] GetAll()
        {
            return flujo;
        }
        public FNE GetProducto(int id)
        {
            foreach (FNE p in flujo)
                if (p.ID == id)
                    return p;
            return null;
        }
        public void Update(int index, FNE e)
        {
            flujo[index].ID = e.ID;
            flujo[index].Inversion = e.Inversion;
            flujo[index].Plazo = e.Plazo;
            flujo[index].Tasa = e.Tasa;
            flujo[index].Ingresos = e.Ingresos;
            flujo[index].Egresos= e.Egresos;
            flujo[index].Inflacion = e.Inflacion;
            flujo[index].Depreciacion1 = e.Depreciacion1;
            flujo[index].VS = e.VS;
            flujo[index].UAI = e.UAI;
            flujo[index].IR = e.IR;
            flujo[index].UDI = e.UDI;
            flujo[index].Depreciacion2 = e.Depreciacion2;
            flujo[index].Fne = e.Fne;
        }
    }
}

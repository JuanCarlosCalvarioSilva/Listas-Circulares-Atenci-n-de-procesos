using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Circulares_Atención_de_procesos
{
    class Lista_circular
    {
        Proceso inicio;

        public void agregar(Proceso nuevo)
        {
            if (inicio == null)
                inicio = nuevo;
            else
            {
                Proceso temp = inicio;
                while (temp.siguiente != inicio)
                {
                    temp = temp.siguiente;
                }
                nuevo.anterior = temp;
                temp.siguiente = nuevo;
            }
            nuevo.siguiente = inicio;
            inicio.anterior = nuevo;
        }

        public Proceso meter()
        {
            if (inicio == null)
                inicio = null;
            else
            {
                if (inicio.tiempo >= 0)
                {                    
                    inicio = sacar();
                    return inicio;
                }                
            }

            return inicio;
        }

        public Proceso sacar()
        {
            if (inicio.siguiente != null)
                inicio = inicio.siguiente;

            return inicio;
        }

        public int quedaban()
        {
            int contador = 0;
            while (inicio.siguiente != inicio)
            {
                contador += inicio.tiempo;
                inicio = inicio.siguiente;
            }
            return contador;
        }
    }
}

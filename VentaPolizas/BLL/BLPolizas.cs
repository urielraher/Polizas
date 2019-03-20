using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLPolizas
    {

        //Trae todas las polizas en order descendiente por fecha de compra
        public List<Polizas> Consultar()
        {
            return new DAOPolizas().Consultar();
        }


        //Trae todas las polizas en order descendiente por fecha de compra
        public Polizas ConsultarByIdPoliza(long idPoliza)
        {
            return new DAOPolizas().ConsultarByIdPoliza(idPoliza);
        }

        //Crear Compra poliza
        public bool InsertarPoliza(Polizas polizas)
        {
            return new DAOPolizas().InsertarPoliza(polizas);
        }


        //Editar  poliza
        public bool EditarPoliza(Polizas polizas)
        {
            return new DAOPolizas().Editar(polizas);
        }


        //Eliminar  poliza
        public bool EliminarPoliza(Polizas polizas)
        {
            return new DAOPolizas().EliminarPoliza(polizas);
        }

    }
}

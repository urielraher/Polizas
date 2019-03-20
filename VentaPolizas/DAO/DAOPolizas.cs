using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOPolizas
    {
        //Consultar todas las polizas
        public List<Polizas> Consultar()
        {
            List<Polizas> lsPolizas = new List<Polizas>();

            try
            {
                using (polizasEntities ctx = new polizasEntities())
                {
                    lsPolizas = ctx.Polizas.OrderByDescending(x => x.FechaCompra).Take(1000).ToList();
                }
            }
            catch (Exception e)
            {
            }

            return lsPolizas;
        }



        //Buscar poliza por ID
        public Polizas ConsultarByIdPoliza(long idPoliza)
        {
            Polizas oPolizas = new Polizas();

            try
            {
                using (polizasEntities ctx = new polizasEntities())
                {
                    oPolizas = ctx.Polizas.Where(x => x.Id == idPoliza).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
            }

            return oPolizas;
        }

        //CrearPoliza
        public bool InsertarPoliza(Polizas polizas)
        {
            try
            {
                using (polizasEntities ctx = new polizasEntities())
                {
                    //Validar registro duplicado
                    if (ctx.Polizas.Where(x => x.NumeroDocumento == polizas.NumeroDocumento && x.PlacaVehiculo == polizas.PlacaVehiculo && x.TipoVehiculo == polizas.TipoVehiculo).Count() > 0)
                    {
                        return false;
                    }


                    ctx.Polizas.Add(polizas);
                    ctx.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {

            }

            return false;

        }


        //Editar Poliza
        public bool Editar(Polizas polizas)
        {
            try
            {
                using (polizasEntities ctx = new polizasEntities())
                {
                    ctx.Entry(polizas).State = EntityState.Modified;
                    ctx.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {

            }

            return false;

        }


        //Eliminar
        public bool EliminarPoliza(Polizas polizas)
        {
            try
            {
                using (polizasEntities ctx = new polizasEntities())
                {
                    ctx.Polizas.Remove(polizas);
                    ctx.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {

            }

            return false;

        }


    }
}

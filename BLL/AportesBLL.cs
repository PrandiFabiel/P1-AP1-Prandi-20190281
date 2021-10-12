using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_AP1_Prandi_20190281.Entidades;
using P1_AP1_Prandi_20190281.DAL;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore; 


namespace P1_AP1_Prandi_20190281.BLL
{
   public class AportesBLL
    {
        public static bool Guardar(Aportes aportes)
        {
            if (!Existe(aportes.AporteId))
                return Insertar(aportes);
            else
                return Modificar(aportes); 
        }

        public static bool Insertar(Aportes aportes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Aportes.Add(aportes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }

            return paso; 
        }

        public static bool Modificar(Aportes aportes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(aportes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }

            return paso; 
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var aporte = contexto.Aportes.Find(id); 

                if(aporte != null)
                {
                    contexto.Aportes.Remove(aporte);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }

            return paso; 
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Aportes.Any(e => e.AporteId == id); 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado; 
        }

        public static Aportes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Aportes aporte = new Aportes();

            try
            {
                aporte = contexto.Aportes.Find(id); 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose(); 
            }

            return aporte; 
        }

        //Para la consulta

        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> criterio)
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                
                lista = contexto.Aportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }


        public static List<Aportes> GetAporte()
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}

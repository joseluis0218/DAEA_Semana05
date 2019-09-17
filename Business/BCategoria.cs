using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entity;

namespace Business
{
    public class BCategoria
    {
        private DCategoria DCategoria = null;

        public List<Categoria> Listar(int IdCategoria)
        {
            List<Categoria> categorias = null;
            try
            {
                DCategoria = new DCategoria();
                categorias = DCategoria.Listar(new Categoria { IdCategoria = IdCategoria });
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return categorias;
        }

        public bool Insertar(Categoria categoria)
        {
            bool result = true;
            List<Categoria> categorias = null;
            int categoriaid = 0;

            try
            {
                DCategoria = new DCategoria();
                categorias = new List<Categoria>();
                categorias = DCategoria.Listar(new Categoria { IdCategoria = 0 });

                categoriaid = categorias.Max(x => x.IdCategoria) + 1;
                categoria.IdCategoria = categoriaid;

                DCategoria.Insertar(categoria);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

            return result; 

        }

        public bool Actualizar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Actualizar(categoria);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

            return result;

        }

        public bool Eliminar(int IdCategoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Eliminar(IdCategoria);
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

            return result;
        }

        public int GetMaxId()
        {
            List<Categoria> categorias = null;
            int idmax = 0;
            try
            {
                DCategoria = new DCategoria();
                categorias = new List<Categoria>();
                categorias = DCategoria.Listar(new Categoria { IdCategoria = 0 });

                idmax = categorias.Max(x => x.IdCategoria) + 1;
                for (int i = 0; i < categorias.Count; i++)
                {
                    if(idmax < categorias[i].IdCategoria)
                    {
                        idmax = categorias[i].IdCategoria;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return idmax;
        }
    }
}

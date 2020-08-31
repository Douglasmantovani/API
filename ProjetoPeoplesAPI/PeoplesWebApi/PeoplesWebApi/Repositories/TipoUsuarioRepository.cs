using PeoplesWebApi.Domains;
using PeoplesWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplesWebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        PeopleskContext dbx = new PeopleskContext();

        public void Atualizar(int id, TiposUsuario tiposUsuario)
        {
            TiposUsuario tiposUsuarioBuscado = dbx.TiposUsuario.Find(id);

            if (tiposUsuario.Titulo != null)
            {
                tiposUsuarioBuscado.Titulo = tiposUsuario.Titulo;
            }

            dbx.Update(tiposUsuarioBuscado);

            dbx.SaveChanges();
        }

        public TiposUsuario BuscarPorID(int id)
        {
            TiposUsuario tiposUsuarioBuscado = dbx.TiposUsuario.Find(id);

            return tiposUsuarioBuscado;
        }

        public void Deletar(int id)
        {
            TiposUsuario tiposUsuarioBuscado = dbx.TiposUsuario.Find(id);

            dbx.Remove(tiposUsuarioBuscado);

            dbx.SaveChanges();
        }

        public List<TiposUsuario> ListarTodos()
        {
            return dbx.TiposUsuario.ToList();
        }
    }
}

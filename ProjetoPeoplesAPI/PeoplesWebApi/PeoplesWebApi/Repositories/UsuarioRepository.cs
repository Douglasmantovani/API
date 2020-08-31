using PeoplesWebApi.Domains;
using PeoplesWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplesWebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        PeopleskContext dbx = new PeopleskContext();

        public void Atualizar(int id, Usuarios usuarios)
        {
            Usuarios usuarioBuscado = dbx.Usuarios.Find(id);

            if (usuarios.Email != null)
            {
                usuarioBuscado.Email = usuarios.Email;
            }

            if (usuarios.Senha != null)
            {
                usuarioBuscado.Senha = usuarios.Senha;
            }

            usuarioBuscado.IdTipoUsuario = 2;

            dbx.Update(usuarioBuscado);

            dbx.SaveChanges();
        }

        public Usuarios BuscarPorID(int id)
        {
            Usuarios usuarioBuscar = dbx.Usuarios.Find(id);

            return usuarioBuscar;
        }

        public void Cadastrar(Usuarios usuarios)
        {
            dbx.Add(usuarios);

            dbx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuarios usuarioBuscado = dbx.Usuarios.Find(id);

            dbx.Remove(usuarioBuscado);

            dbx.SaveChanges();
        }

        public List<Usuarios> ListarTodosUsuarios()
        {
            return dbx.Usuarios.ToList();
        }
    }
}

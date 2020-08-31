using InlockGamesWebAPI.Domains;
using InlockGamesWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlockGamesWebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        InlockContext dbx = new InlockContext();

        public bool Adicionar(Usuario usuario)
        {
            usuario.IdTipoUsuario = 2;

            dbx.Add(usuario);

            dbx.SaveChanges();

            return true;
        }

        public bool Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = dbx.Usuario.Find(id);

            if (usuarioAtualizado.Email!=null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }


            if (usuarioAtualizado.Senha!=null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            dbx.Update(usuarioBuscado);

            dbx.SaveChanges();

            return true;
        }

        public List<Usuario> BuscarPorTipoUsuario()
        {
            return dbx.Usuario.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        public bool Deletar(int id)
        {
            Usuario usuarioBuscado =dbx.Usuario.Find(id);

            dbx.Remove(usuarioBuscado);

            dbx.SaveChanges();

            return true;
        }

        public List<Usuario> ListarUsuarios()
        {
            return dbx.Usuario.ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuarioRepository:IUsuarioRepository
    {
        SenaturContext ctx = new SenaturContext();

        public Usuario BuscarPorEmailSenha(string email,string senha)
        {
            //Usuario usuarioBuscadoPeloId = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id && )

            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u=>u.Email ==email && u.Senha==senha);

            return usuarioBuscado;
        }
        
        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuario.Add(NovoUsuario);

            ctx.SaveChanges();
        }

        public void AtualizarPorid(int id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuario.Find(id);

            if (UsuarioAtualizado.Email != null)
            {
                UsuarioAtualizado.Email = UsuarioAtualizado.Email;
            }

            if (UsuarioAtualizado.Senha != null)
            {
                UsuarioAtualizado.Senha = UsuarioAtualizado.Senha;
            }
            if (UsuarioAtualizado.IdTipousuario != null)
            {
                UsuarioAtualizado.IdTipousuario = UsuarioAtualizado.IdTipousuario;
            }

            ctx.Usuario.Update(UsuarioBuscado);

            ctx.SaveChanges();

        }

        public List<Usuario> ListarUsuarios()
        {
                return ctx.Usuario.Include(U => U.IdTipousuarioNavigation).ToList();
        }

    }
}

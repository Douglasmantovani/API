using SocialMidiaWebApi.Contexts;
using SocialMidiaWebApi.Domains;
using SocialMidiaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SocialMidiaWebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public bool EnviarMensagem(Mensagem mensagem,int idBox,int idUsuario)
        {
            using(SocialContext ctx = new SocialContext())
            {
                try
                {
                    Usuario usuarioBuscado = ctx.Usuario.Find(idUsuario);
                    BoxMensagem bx = ctx.BoxMensagem.FirstOrDefault(u => u.IdBoxMensagem == idBox);
                    if (bx == null)
                    {
                        return false;
                    }
                    else
                    {
                        mensagem.IdUsuarioNavigation = usuarioBuscado;
                        mensagem.IdBoxMensagemDestino = bx.IdBoxMensagem;
                        mensagem.DataMensagem = DateTime.Now;
                        ctx.Add(mensagem);
                        ctx.SaveChanges();
                        return true;
                    }
                }catch(Exception e)
                {
                    return false;
                }
            }
        }
        public List<Mensagem> ListarMensagens()
        {
            using (SocialContext ctx = new SocialContext())
            {
                try
                {
                    return ctx.Mensagem.ToList();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public Usuario Login(string email, string senha)
        {
            using (SocialContext ctx = new SocialContext())
            {
                try
                {
                    Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
                    if (usuarioBuscado == null)
                    {
                        return null;
                    }
                    else
                    {
                        return usuarioBuscado;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            throw new NotImplementedException();
        }
    }
}

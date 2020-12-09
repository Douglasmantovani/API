using SocialMidiaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMidiaWebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Mensagem> ListarMensagens();

        Usuario Login(string email, string senha);

        bool EnviarMensagem(Mensagem mensagem,int boxDestino,int idUsuario);
    }
}

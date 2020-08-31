using InlockGamesWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlockGamesWebAPI.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarUsuarios();

        bool Adicionar(Usuario usuario);

        bool Atualizar(int id, Usuario usuario);

        bool Deletar(int id);

        List<Usuario> BuscarPorTipoUsuario();
    }
}

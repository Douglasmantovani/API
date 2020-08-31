using LojaDeGames.Domains;
using LojaDeGames.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Interfaces
{
    interface IUsuarioRepository
    {
        void Deletar(int id);
        List<Usuario> ListarUsuario(int id);
        Usuario Login(LoginViewModel Usuario);
        bool Cadastrar(string nome, string email, string senha, string telefone);
        bool BuscarPorEmail(String email);
        void Atualizar(int id, Usuario usuario);
        Usuario BuscarPorid(int id);
        Perfil Perfil(int id);
        List<Jogo> Meucarrinho(int id);
    }
}

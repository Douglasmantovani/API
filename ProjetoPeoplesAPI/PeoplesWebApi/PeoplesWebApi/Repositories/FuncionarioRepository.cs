using PeoplesWebApi.Domains;
using PeoplesWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplesWebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        PeopleskContext dbx = new PeopleskContext();

        public void Atualizar(int id, Funcionarios funcionarios)
        {
            Funcionarios funcionarioBuscado = dbx.Funcionarios.Find(id);

            if (funcionarios.Nome != null)
            {
                funcionarioBuscado.Nome = funcionarios.Nome;
            }

            if (funcionarios.Sobrenome != null)
            {
                funcionarioBuscado.Sobrenome = funcionarios.Sobrenome;
            }

            if (funcionarios.DataNascimento != null)
            {
                funcionarioBuscado.DataNascimento = funcionarios.DataNascimento;
            }

            dbx.Update(funcionarioBuscado);

            dbx.SaveChanges();
        }

        public Funcionarios BuscarPorID(int id)
        {
            Funcionarios funcionarioBuscado = dbx.Funcionarios.Find(id);

            return funcionarioBuscado;
        }

        public List<Funcionarios> BuscarPorNome(string nome)
        {
            return dbx.Funcionarios.Where(u => u.Nome == nome).ToList();
        }

        public bool Cadastrar(Funcionarios funcionario)
        {
            dbx.Add(funcionario);

            dbx.SaveChanges();

            return true;
        }

        public void Deletar(int id)
        {
            Funcionarios funcionarioBuscado = dbx.Funcionarios.Find(id);

            dbx.Funcionarios.Remove(funcionarioBuscado);

            dbx.SaveChanges();
        }

        public List<Funcionarios> ListarTodods()
        {
            return dbx.Funcionarios.ToList();
        }
    }
}

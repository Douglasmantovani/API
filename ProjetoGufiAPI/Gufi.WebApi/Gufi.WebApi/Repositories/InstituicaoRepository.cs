using Gufi.WebApi.Contexts;
using Gufi.WebApi.Domains;
using Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        public bool Adicionar(Instituicao InstituicaoNovo)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    ctx.Add(InstituicaoNovo);

                    ctx.SaveChanges();

                    return true; ;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Atualizar(int id, Instituicao Instituicao)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    Instituicao InstituicaoBuscado = ctx.Instituicao.Find(id);
                    if (InstituicaoBuscado == null)
                    {
                        return false;
                    }

                    else if (Instituicao.NomeFantasia != InstituicaoBuscado.NomeFantasia)
                    {
                        InstituicaoBuscado.NomeFantasia = Instituicao.NomeFantasia;
                    }

                    else if (Instituicao.Endereco != InstituicaoBuscado.Endereco)
                    {
                        InstituicaoBuscado.Endereco = Instituicao.Endereco;
                    }

                    else if (Instituicao.Cnpj != InstituicaoBuscado.Cnpj)
                    {
                        InstituicaoBuscado.Cnpj = Instituicao.Cnpj;
                    }

                    ctx.Update(InstituicaoBuscado);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Deletar(int id)
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    Instituicao InstituicaoBuscado = ctx.Instituicao.Find(id);
                    if (InstituicaoBuscado == null)
                    {
                        return false;
                    }
                    ctx.Remove(InstituicaoBuscado);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<Instituicao> ListarInstituicao()
        {
            using (GufiContext ctx = new GufiContext())
            {
                try
                {
                    return ctx.Instituicao.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}

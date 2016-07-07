using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DAL
{
    class EmprestimoDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarEmprestimo(Emprestimo emp)
        {
            try
            {
                ctx.Emprestimo.Add(emp);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Emprestimo> RetornarLista()
        {
            return ctx.Emprestimo.Include("Obra").Include("Cliente").ToList();
        }

        public static List<Emprestimo> RetornarListaEmprestimosEmAberto()
        {
            return ctx.Emprestimo.Include("Obra").Include("Cliente").Where(x => x.EmprestimoStatus == "Em aberto").ToList();
        }

        public static List<Emprestimo> RetornarListaEmprestimosEmAbertoPorCliente(Cliente c)
        {
            return ctx.Emprestimo.Include("Obra").Include("Cliente").Where(x => x.EmprestimoStatus == "Em aberto").Where(y => y.Cliente.ClienteCpf.Equals(c.ClienteCpf)).ToList();
        }
        public static Emprestimo BuscarEmprestimoPorId(Emprestimo emp)
        {
            return ctx.Emprestimo.Include("Obra").Include("Cliente").FirstOrDefault(x => x.EmprestimoId.Equals(emp.EmprestimoId));
        }

        public static bool RemoverEmprestimo(Emprestimo emp)
        {
            try
            {
                ctx.Emprestimo.Remove(emp);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AlterarEmprestimo(Emprestimo emp)
        {
            try
            {
                ctx.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

    }
}

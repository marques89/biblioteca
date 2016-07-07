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
            return ctx.Emprestimo.ToList();
        }

    }
}

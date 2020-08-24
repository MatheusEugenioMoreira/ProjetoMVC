using ProjetoMVC3A.DAL;
using System.Data;
using ProjetoMVC3A.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVC3A.BLL
{
    class tblFornecedorBLL
    {
        private DALBD daoBanco = new DALBD();

        public DataTable ListarFornecedores()
        {
            string sql = string.Format($@"select * from tbl_fornecedor");
            return daoBanco.ExecutarConsulta(sql);
        }





        /*public DataTable ListarFornecedores(string email)
        {
            string sql = string.Format($@"select * from tbl_fornecedor where email_fornecedor = '{email}';");
            return daoBanco.ExecutarConsulta(sql);
        }*/
    }
}

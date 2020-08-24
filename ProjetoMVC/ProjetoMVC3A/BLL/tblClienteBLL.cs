    using ProjetoMVC3A.DAL;
using ProjetoMVC3A.DTO;
using System;
using System.Data;
using System.Drawing;

namespace ProjetoMVC3A.BLL
{
    class   tblClienteBLL
    {
        private DALBD daoBanco = new DALBD();

        public Boolean Autenticar(string email, string senha)
        {
            string consulta = string.Format($@"select * from tbl_cliente where email_cliente = '{email}' and senha_cliente='{senha}';");
            DataTable dt = daoBanco.ExecutarConsulta(consulta);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RecuperarSenha(string email)
        {

            string consulta = string.Format($@"select * from tbl_cliente where email_cliente = '{email}';");
            DataTable dt = daoBanco.ExecutarConsulta(consulta);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["senha_cliente"].ToString();

            }
            else
            {
                return "";
            }
        }

        public int VerificarTipoUsuario(string email)
        {
            string consulta = string.Format($@"select * from tbl_cliente where email_cliente = '{email}';");
            DataTable dt = daoBanco.ExecutarConsulta(consulta);
            if (dt.Rows.Count == 1)
            {
                return Convert.ToInt32(dt.Rows[0]["tp_usuario"].ToString());

            }
            else
            {
                return 1;
            }
        }

        public void AlterarSenhaCliente(string email, string senha)
        {
            string sql = string.Format($@"UPDATE tbl_cliente set senha_cliente = '{senha}' where email_cliente = '{email}';");
            daoBanco.ExecutarComando(sql);
        }

        // Criação de Metodo para selecionar os dados do cliente - Polimorfismo 
        public DataTable ListarClientes(string email)
        {
            string sql = string.Format($@"select * from tbl_cliente where email_cliente = '{email}';");
            return daoBanco.ExecutarConsulta(sql);
        }
        public DataTable ListarClientes()
        {
            string sql = string.Format($@"select * from tbl_cliente");
            return daoBanco.ExecutarConsulta(sql);
        }
        // metodo utilizado para alterar dados do cliente
        public void AlterarCliente(tblClienteDTO DtoCliente)
        {
            string sql = string.Format($@"UPDATE tbl_cliente set nome_cliente = '{DtoCliente.Nome_cliente}',
                                                                 sobrenome_cliente = '{DtoCliente.Sobrenome_cliente}',
                                                                 cpf_cliente = '{DtoCliente.Cpf_cliente}',
                                                                 senha_cliente = '{DtoCliente.Senha_cliente}'
                                                   where email_cliente = '{DtoCliente.Email_cliente}';");
            daoBanco.ExecutarComando(sql);
        }

        //Metodo para Inserir Cliente no Banco de Dados
        public void InserirCliente(tblClienteDTO ObjCliente)
        {
            string sql = string.Format($@"INSERT INTO tbl_cliente VALUES (NULL, '{ObjCliente.Nome_cliente}',
                                                                                '{ObjCliente.Sobrenome_cliente}',
                                                                                '{ObjCliente.Email_cliente}',
                                                                                '{ObjCliente.Senha_cliente}',
                                                                                '{ObjCliente.Cpf_cliente}',    
                                                                                '{ObjCliente.Tp_usuario}');");
            daoBanco.ExecutarComando(sql);
        }
        // Metodo utilizado para excluir Cliente no Banco
        public void ExcluirCliente(tblClienteDTO objCliente)
        {
            string sql = string.Format($@"DELETE FROM tbl_cliente where id_cliente = {objCliente.Id_cliente};");
            daoBanco.ExecutarComando(sql);
        }
       
        // Metodo para Consultar Clientes no Banco
        public DataTable PesquisarClientes(string condicao)
        {
            string sql = string.Format($@"select * from tbl_cliente where " + condicao);
            return daoBanco.ExecutarConsulta(sql);
        }

    }
   
}

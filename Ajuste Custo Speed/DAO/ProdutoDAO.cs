using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ajuste_Custo_Speed.Model;
using Oracle.ManagedDataAccess.Client;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Ajuste_Custo_Speed.DAO
{
    public class ProdutoDAO
    {
        public List<Produto> getProdutos(int codprod)
        {
            List<Produto> produtos = new List<Produto>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT CODPROD, DESCRICAO FROM PCPRODUT WHERE 1 = 1 ");
            if (codprod > 0)
            {
                sql.Append(" AND CODPROD = :codprod");
            }
            sql.Append(" ORDER BY CODPROD");

            using (OracleConnection conn = Conexao.GetConnection())
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn))
                {
                    if (codprod > 0)
                    {
                        cmd.Parameters.Add(new OracleParameter("codprod", codprod));
                    }
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                Codigo = Convert.ToInt32(reader["CODPROD"]),
                                Descricao = reader["DESCRICAO"].ToString(),
                                CustoAtual = 0,
                                CustoNovo = 0
                            };
                            produtos.Add(produto);
                        }
                    }
                }
            }
            return produtos;
        }

        public void atualizarCusto(int codprod, decimal novoCusto, string colunaCusto)
        {
            using (OracleConnection conn = Conexao.GetConnection())
            {
                conn.Open();

                // Monta o SQL dinamicamente apenas com o nome da coluna
                string sql = $"UPDATE PCEST SET {colunaCusto} = :novoCusto WHERE CODPROD = :codprod AND CODFILIAL = 1";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("novoCusto", novoCusto));
                    cmd.Parameters.Add(new OracleParameter("codprod", codprod));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

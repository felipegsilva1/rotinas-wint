using DocumentFormat.OpenXml.Vml;
using Markup_Laborsil.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markup_Laborsil.DAO
{
    public class ProdutoDAO
    {
        public List<Produto> getProdutos(int? CodProd, string descricao)
        {
            List<Produto> produtos = new List<Produto>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT codprod, descricao, codauxiliar, codmarca FROM PCPRODUT WHERE 1 = 1 ");

            if (CodProd.HasValue)
            {
                sql.Append(" AND CODPROD = :pCodProd ");
            }
            if (!string.IsNullOrEmpty(descricao))
            {
                sql.Append(" AND UPPER(DESCRICAO) LIKE UPPER(:pdescricao) "); 
            }

            sql.Append(" AND OBS2 <> 'FL' AND DTEXCLUSAO IS NULL ORDER BY CODPROD ");

            using (OracleConnection connection = Conexao.GetConnection())
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(sql.ToString(), connection))
                {
                    if (CodProd.HasValue)
                    {
                        command.Parameters.Add("pCodProd", OracleDbType.Int32).Value = CodProd.Value;
                    }
                    if (!string.IsNullOrEmpty(descricao))
                    {
                        command.Parameters.Add("pdescricao", OracleDbType.Varchar2).Value = "%" + descricao + "%";
                    }
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                codProd = reader.GetInt32(0),
                                descricao = reader.IsDBNull(1) ? null : reader.GetString(1),
                                codAuxiliar = reader.IsDBNull(2) ? (long?)null : reader.GetInt64(2),
                                codMarca = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3)
                            };
                            produtos.Add(produto);
                        }
                    }
                }
            }



            return produtos;

        }

        public List<Produto> getProdutosMkp(int? CodProd, string descricao, int? codMarca, string atuAuto, string tipoAtu)
        {
            List<Produto> produtos = new List<Produto>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT codprod, descricao, codauxiliar, codmarca, NVL(AD_ATUAUTOMATICO, 'N') AS AD_ATUAUTOMATICO, nvl(AD_PERCMARKUP, 0) as AD_PERCMARKUP, AD_TIPOATUPRECO  FROM PCPRODUT WHERE 1 = 1 ");

            if (CodProd.HasValue)
            {
                sql.Append(" AND CODPROD = :pCodProd ");
            }
            if (!string.IsNullOrEmpty(descricao))
            {
                sql.Append(" AND UPPER(DESCRICAO) LIKE UPPER(:pdescricao) ");
            }
            if (codMarca.HasValue)
            {
                sql.Append(" AND CODMARCA = :pcodMarca ");
            }
            if (!string.IsNullOrEmpty(atuAuto))
            {
                sql.Append(" AND NVL(AD_ATUAUTOMATICO, 'N') = :atuAuto ");
            }
            if (!string.IsNullOrEmpty(tipoAtu))
            {
                sql.Append(" AND AD_TIPOATUPRECO = :tipoAtu ");
            }

            sql.Append(" AND NVL(REVENDA, 'N') = 'S' AND OBS2 <> 'FL' AND DTEXCLUSAO IS NULL AND CODMARCA <> 1821 ORDER BY CODPROD ");

            using (OracleConnection connection = Conexao.GetConnection())
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(sql.ToString(), connection))
                {
                    if (CodProd.HasValue)
                    {
                        command.Parameters.Add("pCodProd", OracleDbType.Int32).Value = CodProd.Value;
                    }
                    if (!string.IsNullOrEmpty(descricao))
                    {
                        command.Parameters.Add("pdescricao", OracleDbType.Varchar2).Value = "%" + descricao + "%";
                    }
                    if (codMarca.HasValue)
                    {
                        command.Parameters.Add("pcodMarca", OracleDbType.Int32).Value = codMarca.Value;
                    }
                    if (!string.IsNullOrEmpty(atuAuto))
                    {
                        command.Parameters.Add("atuAuto", OracleDbType.Varchar2).Value = atuAuto;
                    }
                    if (!string.IsNullOrEmpty(tipoAtu))
                    {
                        command.Parameters.Add("tipoAtu", OracleDbType.Varchar2).Value = tipoAtu;
                    }
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                codProd = reader.GetInt32(0),
                                descricao = reader.IsDBNull(1) ? null : reader.GetString(1),
                                codAuxiliar = reader.IsDBNull(2) ? (long?)null : reader.GetInt64(2),
                                codMarca = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                                atualizaAuto = reader.IsDBNull(4) ? null : reader.GetString(4),
                                percMkp = reader.IsDBNull(5) ? (decimal?)null : reader.GetDecimal(5),
                                tipoAtuPreco = reader.IsDBNull(6) ? null : reader.GetString(6)
                            };
                            produtos.Add(produto);
                        }
                    }
                }
            }



            return produtos;

        }

        public void AtualizarProduto(int codProd, string atualizaAuto, string tipoAtuPreco, decimal percMkp)
        {
            using (OracleConnection conn = Conexao.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE PCPRODUT SET AD_ATUAUTOMATICO = :atu, AD_TIPOATUPRECO = :tipo, AD_PERCMARKUP = :perc WHERE CODPROD = :codProd";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("atu", OracleDbType.Varchar2).Value = atualizaAuto;
                    cmd.Parameters.Add("tipo", OracleDbType.Varchar2).Value = tipoAtuPreco;
                    cmd.Parameters.Add("perc", OracleDbType.Decimal).Value = percMkp;
                    cmd.Parameters.Add("codProd", OracleDbType.Int32).Value = codProd;

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markup_Laborsil.Model;
using Oracle.ManagedDataAccess.Client;

namespace Markup_Laborsil.DAO
{
    public class CabPromocaoDAO
    {
        public List<CabPromocao> ObterCabecalhoPromocoes(int? codPromocao = null, string descPromocao = null)
        {
            List<CabPromocao> cabecalhos = new List<CabPromocao>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT CODPROMOCAOMED, DESCRICAODETALHADA FROM PCPROMOCAOMED WHERE 1 = 1 AND DATAFINAL >= TRUNC(SYSDATE) ");
            
            if (codPromocao.HasValue)
            {
                sql.Append(" AND CODPROMOCAOMED = :pcodPromocao ");
            }
            if (!string.IsNullOrEmpty(descPromocao))
            {
                sql.Append(" AND UPPER(DESCRICAODETALHADA) LIKE UPPER(:pdescPromocao) ");
            }

            sql.Append(" ORDER BY CODPROMOCAOMED ");

            using (OracleConnection connection = Conexao.GetConnection())
            {
                using (OracleCommand command = new OracleCommand(sql.ToString(), connection))
                {
                    if (codPromocao.HasValue)
                    {
                        command.Parameters.Add("pcodPromocao", OracleDbType.Int32).Value = codPromocao.Value;
                    }
                    if (!string.IsNullOrEmpty(descPromocao))
                    {
                        command.Parameters.Add("pdescPromocao", OracleDbType.Varchar2).Value = "%" + descPromocao + "%";
                    }
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CabPromocao cabecalho = new CabPromocao
                            {
                                codPromocao = reader.GetInt32(0),
                                descPromocao = reader.GetString(1)
                            };
                            cabecalhos.Add(cabecalho);
                        }
                    }
                }
                return cabecalhos;
            }
        }

        public List<CabPromocao> getPromocoesparaAtualizacao()
        {
            List<CabPromocao> cabecalhos = new List<CabPromocao>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM AD_TABPRECOMKP WHERE 1 = 1 ");
            sql.Append(" ORDER BY CODPROMOCAOMED ");

            using (OracleConnection connection = Conexao.GetConnection())
            {
                using (OracleCommand command = new OracleCommand(sql.ToString(), connection))
                {
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CabPromocao cabecalho = new CabPromocao
                            {
                                codPromocao = reader.GetInt32(0),
                                descPromocao = reader.GetString(1)
                            };
                            cabecalhos.Add(cabecalho);
                        }
                    }
                }
                return cabecalhos;
            }
        }

        public void AtualizarTabPreco(int codPromocaMed, string atualiza)
        {
            using (OracleConnection conn = Conexao.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE AD_TABPRECOMKP SET ATUAUTOMATICO = :atu WHERE codpromocaomed = :codPromocaoMed";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("atu", OracleDbType.Varchar2).Value = atualiza;
                    cmd.Parameters.Add("codPromocaoMed", OracleDbType.Varchar2).Value = codPromocaMed;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertTabPreco(int codPromocaMed, string descricaoMed)
        {
            using (OracleConnection conn = Conexao.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO AD_TABPRECOMKP (CODPROMOCAOMED, DESCRICAO) VALUES (:CODPROMOCAOMED, :DESCRICAO) ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("codPromocaoMed", OracleDbType.Varchar2).Value = codPromocaMed;
                    cmd.Parameters.Add("descricao", OracleDbType.Varchar2).Value = descricaoMed;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarTabPreco(int codPromocaMed)
        {
            using (OracleConnection conn = Conexao.GetConnection())
            {
                conn.Open();
                string sql = @"DELETE FROM AD_TABPRECOMKP WHERE CODPROMOCAOMED = :codPromocaoMed ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("codPromocaoMed", OracleDbType.Varchar2).Value = codPromocaMed;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

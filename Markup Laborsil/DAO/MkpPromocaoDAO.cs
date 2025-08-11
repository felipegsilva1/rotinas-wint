using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markup_Laborsil.Model;
using Oracle.ManagedDataAccess.Client;

namespace Markup_Laborsil.DAO
{
    public class MkpPromocaoDAO
    {
        public List<MkpPromocao> getMkpPromocao(int? codprod, int? codpromocaomed, int? codmarca)
        {
            List<MkpPromocao> mkppromo = new List<MkpPromocao>();
            StringBuilder sql = new StringBuilder();

            
            sql.Append("SELECT * FROM ad_mkp_prod_promo WHERE 1 = 1 ");

            List<OracleParameter> parameters = new List<OracleParameter>();

            if (codprod.HasValue)
            {
                sql.Append(" AND codprod = :pCodProd ");
                parameters.Add(new OracleParameter("pCodProd", codprod.Value));
            }
            if (codpromocaomed.HasValue)
            {
                sql.Append(" AND codpromo = :pCodPromo ");
                parameters.Add(new OracleParameter("pCodPromo", codpromocaomed.Value));
            }
            if (codmarca.HasValue)
            {
                sql.Append(" AND codmarca = :pCodMarca ");
                parameters.Add(new OracleParameter("pCodMarca", codmarca.Value));
            }

            sql.Append(" ORDER BY codprod, codpromo ");

            using (OracleConnection connection = Conexao.GetConnection())
            {
                using (OracleCommand command = new OracleCommand(sql.ToString(), connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());

                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MkpPromocao promocoes = new MkpPromocao
                            {
                                codProd = reader.GetInt32(reader.GetOrdinal("CODPROD")),
                                descProd = reader.IsDBNull(reader.GetOrdinal("DESCRICAO")) ? null : reader.GetString(reader.GetOrdinal("DESCRICAO")),
                                codMarca = reader.GetInt32(reader.GetOrdinal("CODMARCA")) ,
                                marca = reader.IsDBNull(reader.GetOrdinal("MARCA")) ? null : reader.GetString(reader.GetOrdinal("MARCA")),
                                codPromocao = reader.GetInt32(reader.GetOrdinal("CODPROMO")),
                                descPromocao = reader.IsDBNull(reader.GetOrdinal("PROMOCAO")) ? null : reader.GetString(reader.GetOrdinal("PROMOCAO")),
                                permkp = reader.IsDBNull(reader.GetOrdinal("PERMKP")) ? 0 : reader.GetDecimal(reader.GetOrdinal("PERMKP"))

                            };
                            mkppromo.Add(promocoes);
                        }
                    }
                }
            }
            return mkppromo;
        }

        public bool VerificarExisteProdutoEmPromocao(int codprod, int codpromocaomed)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT 1 FROM ad_mkp_prod_promo WHERE codprod = :pCodProd AND codpromo = :pCodPromo");

            using (OracleConnection connection = Conexao.GetConnection())
            {
                using (OracleCommand command = new OracleCommand(sql.ToString(), connection))
                {
                    command.Parameters.Add(new OracleParameter("pCodProd", codprod));
                    command.Parameters.Add(new OracleParameter("pCodPromo", codpromocaomed));

                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Se o reader conseguir ler uma linha, significa que o produto existe na promoção
                        return reader.Read();
                    }
                }
            }
        }

        public void AtualizarMkpPromocao(int codProd, int codPromocaMed, decimal perMkp)
        {
            using (OracleConnection conn = Conexao.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE ad_mkp_prod_promo SET PERMKP = :perMkp WHERE codpromo = :codPromocaoMed and codprod = :codprod ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("perMkp", OracleDbType.Varchar2).Value = perMkp;
                    cmd.Parameters.Add("codPromocaoMed", OracleDbType.Varchar2).Value = codPromocaMed;
                    cmd.Parameters.Add("codprod", OracleDbType.Varchar2).Value = codProd;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertMkpPromocao(int codProd, decimal perMkp, string descricao, string marca, int codpromo, string promocao, int codmarca)
        {
            using (OracleConnection conn = Conexao.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO ad_mkp_prod_promo (codprod, descricao, marca, codpromo, promocao, permkp, codmarca) VALUES (:codprod, :descricao, :marca, :codpromo, :promocao, :permkp, :codmarca) ";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("codprod", OracleDbType.Varchar2).Value = codProd;
                    cmd.Parameters.Add("descricao", OracleDbType.Varchar2).Value = descricao;
                    cmd.Parameters.Add("marca", OracleDbType.Varchar2).Value = marca;
                    cmd.Parameters.Add("codpromo", OracleDbType.Varchar2).Value = codpromo;
                    cmd.Parameters.Add("promocao", OracleDbType.Varchar2).Value = promocao;
                    cmd.Parameters.Add("permkp", OracleDbType.Varchar2).Value = perMkp;
                    cmd.Parameters.Add("codmarca", OracleDbType.Varchar2).Value = codmarca;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarMkpPromocao(int? codPromocao, int? codprod)
        {
            StringBuilder sql = new StringBuilder("DELETE FROM ad_mkp_prod_promo");
            StringBuilder conditions = new StringBuilder();

            if (codPromocao.HasValue)
            {
                conditions.Append("codpromo = :pcodPromocao");
            }

            if (codprod.HasValue)
            {
                if (conditions.Length > 0)
                {
                    conditions.Append(" AND ");
                }
                conditions.Append("codprod = :pCodProd");
            }

            // Condições fixas sempre aplicadas
            if (conditions.Length > 0)
            {
                conditions.Append(" AND ");
            }

            if (conditions.Length > 0)
            {
                sql.Append(" WHERE ").Append(conditions.ToString());
            }

            using (Oracle.ManagedDataAccess.Client.OracleConnection conn = Conexao.GetConnection())
            {
                conn.Open();

                using (Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sql.ToString();

                    if (codPromocao.HasValue)
                    {
                        cmd.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("pcodPromocao", codPromocao.Value));
                    }
                    if (codprod.HasValue)
                    {
                        cmd.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("pCodProd", codprod.Value));
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


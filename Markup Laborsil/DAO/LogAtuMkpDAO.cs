using Oracle.ManagedDataAccess.Client;
using Markup_Laborsil.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Markup_Laborsil.DAO
{
    public class LogAtuMkpDAO
    {
        public List<LogAtuMkp> ObterLogMkp(int? CodPromocaoMed = null, int? CodProd = null, DateTime? DataInic = null, DateTime? DataFim = null, string Marca = null)
        {
            List<LogAtuMkp> listaLog = new List<LogAtuMkp>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT codprod, descricao, codauxiliar, marca, valorultent, precofabrica, percmarkup, desconto, data, maquina, usuario, programa, codpromocaomed ");
            sql.Append("FROM AD_LOGMKP ");
            sql.Append("WHERE 1 = 1 ");

            // Filtro de Promoção
            if (CodPromocaoMed.HasValue)
            {
                sql.Append("AND CODPROMOCAOMED = :pCodPromocaoMed ");
            }
            // Filtro de Produto
            if (CodProd.HasValue)
            {
                sql.Append("AND CODPROD = :pCodProd ");
            }
            // Filtro de Marca
            if (!string.IsNullOrEmpty(Marca))
            {
                sql.Append("AND MARCA = :pMarca ");
            }
            // Filtro de Data
            if (DataInic.HasValue)
            {
                sql.Append("AND trunc(DATA) BETWEEN trunc(:pDataInicio) AND trunc(:pDataFim) ");
            }

            sql.Append(" ORDER BY CODPROD, DATA ");


            using (OracleConnection connection = Conexao.GetConnection())
            {
                using (OracleCommand command = new OracleCommand(sql.ToString(), connection))
                {
                    // Adicionar parâmetros para evitar SQL Injection
                    if (CodPromocaoMed.HasValue)
                    {
                        command.Parameters.Add("pCodPromocaoMed", OracleDbType.Int32).Value = CodPromocaoMed.Value;
                    }
                    if (CodProd.HasValue)
                    {
                        command.Parameters.Add("pCodProd", OracleDbType.Int32).Value = CodProd.Value;
                    }
                    if (!string.IsNullOrEmpty(Marca))
                    {
                        command.Parameters.Add("pMarca", OracleDbType.Varchar2).Value = Marca;
                    }
                    if (DataInic.HasValue)
                    {
                        command.Parameters.Add("pDataInicio", OracleDbType.Date).Value = DataInic.Value;
                    }
                    if (DataFim.HasValue)
                    {
                        command.Parameters.Add("pDataFim", OracleDbType.Date).Value = DataFim.Value;
                    }

                    try
                    {
                        connection.Open();

                        // Exibir SQL com os parâmetros no console
                        StringBuilder debugQuery = new StringBuilder(sql.ToString());
                        foreach (OracleParameter param in command.Parameters)
                        {
                            debugQuery.AppendLine($" | {param.ParameterName}: {param.Value}");
                        }

                        Console.WriteLine(debugQuery.ToString());


                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaLog.Add(new LogAtuMkp
                                {
                                    CodProd = reader.IsDBNull(reader.GetOrdinal("CODPROD")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CODPROD")),
                                    Descricao = reader.IsDBNull(reader.GetOrdinal("DESCRICAO")) ? null : reader.GetString(reader.GetOrdinal("DESCRICAO")),
                                    CodAuxiliar = reader.IsDBNull(reader.GetOrdinal("CODAUXILIAR")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("CODAUXILIAR")),
                                    Marca = reader.IsDBNull(reader.GetOrdinal("MARCA")) ? null : reader.GetString(reader.GetOrdinal("MARCA")),
                                    ValorUltEnt = reader.IsDBNull(reader.GetOrdinal("VALORULTENT")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("VALORULTENT")),
                                    PrecoFabrica = reader.IsDBNull(reader.GetOrdinal("PRECOFABRICA")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("PRECOFABRICA")),
                                    PercMarkup = reader.IsDBNull(reader.GetOrdinal("PERCMARKUP")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("PERCMARKUP")),
                                    Desconto = reader.IsDBNull(reader.GetOrdinal("DESCONTO")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("DESCONTO")),
                                    Data = reader.IsDBNull(reader.GetOrdinal("DATA")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DATA")),
                                    Maquina = reader.IsDBNull(reader.GetOrdinal("MAQUINA")) ? null : reader.GetString(reader.GetOrdinal("MAQUINA")),
                                    Usuario = reader.IsDBNull(reader.GetOrdinal("USUARIO")) ? null : reader.GetString(reader.GetOrdinal("USUARIO")),
                                    Programa = reader.IsDBNull(reader.GetOrdinal("PROGRAMA")) ? null : reader.GetString(reader.GetOrdinal("PROGRAMA")),
                                    CodPromocaoMed = reader.IsDBNull(reader.GetOrdinal("CODPROMOCAOMED")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CODPROMOCAOMED"))
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao obter dados de LogMkp: " + ex.Message, ex);
                    }
                }
            }
            return listaLog;
        }
    }
}
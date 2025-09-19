using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicoMacro.Model;

namespace ServicoMacro.DAO
{
    public class ServiceDAO
    {
        public List<Servicos> getService(int? codServices, string status)
        {
            List<Servicos> lista = new List<Servicos>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM AD_SERVICE WHERE 1 = 1");

            if (codServices.HasValue)
            {
                sql.Append(" AND CODSERVICE = :codServices");
            }
            if (!string.IsNullOrEmpty(status))
            {
                sql.Append(" AND STATUS = :STATUS");
            }
            sql.Append(" ORDER BY CODSERVICE");

            using (OracleConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn))
                {
                    if (codServices.HasValue)
                    {
                        cmd.Parameters.Add(new OracleParameter("codServices", codServices.Value));
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        cmd.Parameters.Add(new OracleParameter("STATUS", status));
                    }
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Servicos servico = new Servicos
                            {
                                codService = reader.GetInt32(reader.GetOrdinal("CODSERVICE")),
                                nomeService = reader.GetString(reader.GetOrdinal("NOMESERVICE")),
                                directorService = reader.GetString(reader.GetOrdinal("DIRSERVICE")),
                                statusService = reader.GetString(reader.GetOrdinal("STATUS")),
                                horaService = reader.IsDBNull(reader.GetOrdinal("HORASERVICE")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("HORASERVICE")),
                                minutoService = reader.IsDBNull(reader.GetOrdinal("MINUTOSERVICE")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MINUTOSERVICE")),
                                dataService = reader.IsDBNull(reader.GetOrdinal("DATASERVICE")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DATASERVICE")),
                                macroService = reader.GetString(reader.GetOrdinal("MACROSERVICE"))
                            };
                            lista.Add(servico);
                        }
                    }
                }
            }

            return lista;
        }

        public bool updateService(Servicos service)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE AD_SERVICE SET NOMESERVICE = :NOMESERVICE, " +
                                             "DIRSERVICE = :DIRSERVICE, " +
                                             "HORASERVICE = :HORASERVICE, " +
                                             "MINUTOSERVICE = :MINUTOSERVICE, " +
                                             "DATASERVICE = :DATASERVICE, " +
                                             "MACROSERVICE = :MACROSERVICE, " +
                                             "STATUS = :STATUS " + 
                                             "WHERE CODSERVICE = :CODSERVICE");

            using (OracleConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn))
                {
                    cmd.Parameters.Add(new OracleParameter("NOMESERVICE", service.nomeService));
                    cmd.Parameters.Add(new OracleParameter("DIRSERVICE", service.directorService));
                    cmd.Parameters.Add(new OracleParameter("HORASERVICE", service.horaService));
                    cmd.Parameters.Add(new OracleParameter("MINUTOSERVICE", service.minutoService));
                    cmd.Parameters.Add(new OracleParameter("DATASERVICE", service.dataService.HasValue ? (object)service.dataService.Value : DBNull.Value));
                    cmd.Parameters.Add(new OracleParameter("MACROSERVICE", service.macroService));
                    cmd.Parameters.Add(new OracleParameter("STATUS", service.statusService));
                    cmd.Parameters.Add(new OracleParameter("CODSERVICE", service.codService));

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public void insertService(string nomeService, string dirService, int horaService, int minutoService, DateTime? dataService, string macroService, string status)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO AD_SERVICE (CODSERVICE, NOMESERVICE, DIRSERVICE, HORASERVICE, MINUTOSERVICE, DATASERVICE, MACROSERVICE, STATUS, DATACADASTRO) " +
                       "VALUES (SEQ_AD_SERVICE.NEXTVAL, :NOMESERVICE, :DIRSERVICE, :HORASERVICE, :MINUTOSERVICE, :DATASERVICE, :MACROSERVICE, :STATUS, SYSDATE)");
            using (OracleConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn))
                {
                    cmd.Parameters.Add(new OracleParameter("NOMESERVICE", nomeService));
                    cmd.Parameters.Add(new OracleParameter("DIRSERVICE", dirService));
                    cmd.Parameters.Add(new OracleParameter("HORASERVICE", horaService));
                    cmd.Parameters.Add(new OracleParameter("MINUTOSERVICE", minutoService));
                    cmd.Parameters.Add(new OracleParameter("DATASERVICE", dataService.HasValue ? (object)dataService.Value : DBNull.Value));
                    cmd.Parameters.Add(new OracleParameter("MACROSERVICE", macroService));
                    cmd.Parameters.Add(new OracleParameter("STATUS", status));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deleteService(int codService)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM AD_SERVICE WHERE CODSERVICE = :CODSERVICE");
            using (OracleConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn))
                {
                    cmd.Parameters.Add(new OracleParameter("CODSERVICE", codService));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int getNextServiceCode()
        {
            int nextCode = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT max(codservice) + 1 as NEXTVAL from ad_service");
            using (OracleConnection conn = conexao.GetConnection())
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(sql.ToString(), conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nextCode = reader.GetInt32(reader.GetOrdinal("NEXTVAL"));
                        }
                    }
                }
            }
            return nextCode;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markup_Laborsil.Model;
using Oracle.ManagedDataAccess.Client;

namespace Markup_Laborsil.DAO
{
    public class MarcaDAO
    {
        public List<Marca> obterMarcas(int? codMarca, string descMarca)
        {
            List<Marca> marcas = new List<Marca>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT codmarca, marca, decode(Ad_Atuautomatico, 'S', 'Sim', 'N', 'Nao') AS ATUALIZAAUTO, Ad_Tipoatupreco AS TIPOATU FROM PCMARCA WHERE 1 = 1 ");
            if (codMarca.HasValue)
            {
                sql.Append(" AND codmarca = :pcodMarca ");
            }
            if (!string.IsNullOrEmpty(descMarca))
            {
                sql.Append(" AND UPPER(marca) LIKE UPPER(:pdescMarca) ");
            }

            sql.Append(" AND ATIVO = 'S' ORDER BY MARCA ");

            using (OracleConnection connection = Conexao.GetConnection())
            {
                using (OracleCommand command = new OracleCommand(sql.ToString(), connection))
                {
                    if (codMarca.HasValue)
                    {
                        command.Parameters.Add("pcodMarca", OracleDbType.Int32).Value = codMarca.Value;
                    }
                    if (!string.IsNullOrEmpty(descMarca))
                    {
                        command.Parameters.Add("pdescMarca", OracleDbType.Varchar2).Value = "%" + descMarca + "%";
                    }

                    {
                        connection.Open();
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Marca marca = new Marca
                                {
                                    CodMarca = reader.GetInt32(0),
                                    descMarca = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    AtualizaAuto = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                                    TipoAtuPreco = !reader.IsDBNull(3) ? reader.GetString(3) : null
                                };
                                marcas.Add(marca);
                            }
                        }
                    }
                }
                return marcas;
            }
        }
    }
}

using Ajuste_Custo_Speed;
using Ajuste_Custo_Speed.Model;
using DocumentFormat.OpenXml.ExtendedProperties;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajuste_Custo_Speed
{
    public class Conexao
    {
        //private static string _connectionString = "User Id=LABORSIL;Password=L4BO3SIL;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=132.226.252.205)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=WINT)))";
        //private static string _connectionString = "User Id=LABORSIL;Password=L4BO3SIL;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.97.100)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=WINT)))";
        private static string _connectionString = $"User Id={Program.UsuarioBD};Password={Program.SenhaBD};Data Source={Program.AliasBD}";
        //private static string _connectionString = "User Id=TESTE;Password=TESTE;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.97.100)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=TESTE)))";

        //Antes de compilar confirme se o ShadowType esta "None"

        //Abra o projeto no Visual Studio 2022
        //Vá em Projetos > Gerenciar Pacotes NuGet
        //Instale o pacote Costura.Fody
        //Compile o projeto(Compilação > Compilação Solução)
        //O executável único será gerado automaticamente

        public static OracleConnection GetConnection()
        {
            return new OracleConnection(_connectionString);
        }
    }
}
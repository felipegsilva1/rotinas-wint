using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markup_Laborsil
{
    public class Conexao
    {
        //private static string _connectionString = "User Id=LABORSIL;Password=L4BO3SIL;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=132.226.252.205)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=WINT)))";
        private static string _connectionString = "User Id=LABORSIL;Password=L4BO3SIL;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.97.100)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=WINT)))";
        //private static string _connectionString = $"User Id={Program.UsuarioBD};Password={Program.SenhaBD};Data Source={Program.AliasBD}";


        //Abra o Developer Command Prompt for VS 2022
        //Va para a pasta do projeto - cd "C:\Projetos\rotinas-wint\Markup Laborsil"
        //msbuild "Markup Laborsil.csproj" /p:Configuration=Release

        public static OracleConnection GetConnection()
        {
            return new OracleConnection(_connectionString);
        }
    }
}

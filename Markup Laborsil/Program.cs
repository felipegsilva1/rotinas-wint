using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Markup_Laborsil
{
    //Selecione o bloco de código, segure Ctrl, pressione K, solte, depois pressione C (para comentar) ou U (para descomentar).
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// 

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

        //internal static class Program
        //{
        //    /// <summary>
        //    /// Ponto de entrada principal para o aplicativo.
        //    /// </summary>
        //    /// 

        //    public static string UsuarioWT;
        //    public static string SenhaBD;
        //    public static string AliasBD;
        //    public static string UsuarioBD;
        //    public static string CodRotina;


        //    [STAThread]
        //    public static void Main(String[] args)
        //    {
        //        if (args.Length < 5)
        //        {
        //            MessageBox.Show("Erro: Parâmetros do WinThor não foram informados corretamente.");
        //            return;
        //        }

        //        UsuarioWT = args[0];
        //        SenhaBD = args[1];
        //        AliasBD = args[2];
        //        UsuarioBD = args[3];
        //        CodRotina = args[4];

        //        Console.WriteLine(args[0]);
        //        Application.EnableVisualStyles();
        //        Application.SetCompatibleTextRenderingDefault(false);
        //        Application.Run(new Form1());
        //    }
        //}
}

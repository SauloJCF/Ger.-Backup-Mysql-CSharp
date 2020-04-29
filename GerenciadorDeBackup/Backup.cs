using MySql.Data.MySqlClient;
using System;

namespace GerenciadorDeBackup
{
    public class Backup
    {

        public static void FazerBackup(string[] dados)
        {

            String servidor = dados[0];
            String usuario = dados[1];
            String senha = dados[2];
            String banco = dados[3];
            String local = dados[4];

            string constring = "server=" + servidor + ";user=" + usuario + ";pwd=" + senha + ";database=" + banco + ";"+"SslMode = none;";
            constring += "charset=utf8;convertzerodatetime=true;";

            // define o nome do arquivo de backup de acordo com a data e hora.
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string ano = DateTime.Now.Year.ToString();
            string hora = DateTime.Now.ToLongTimeString().Replace(":", "");
            string nomeDoArquivo = ano + mes + dia + "_" + hora;
            // fim

            // gera o conteúdo do arquivo de backup e salva no local definido no config.dat
            string arquivo = local + "\\" + nomeDoArquivo + ".sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(arquivo);
                        conn.Close();
                    }
                }
            }
        }
    }
}

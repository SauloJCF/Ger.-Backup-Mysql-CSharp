using System;
using System.IO;

namespace GerenciadorDeBackup
{
    class Arquivo
    {
        private const string caminho = @"config.dat";

        public static bool TestarArquivo()
        {
            try
            {
                string[] dados = File.ReadAllLines(caminho);
                if (dados.Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (IOException e)
            {
                throw e;
            }

        }

        public static byte[] LerArquivo()
        {
            try
            {
                string[] dados = File.ReadAllLines(caminho);
                byte[] bytesOrganizados = new byte[dados.Length];
                int cont = 0;
                foreach (string item in dados)
                {
                    bytesOrganizados[cont] = byte.Parse(item);
                    cont++;
                }
                return bytesOrganizados;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public static void EscreverNoArquivo(byte[] dadosCriptografados)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(caminho))
                {
                    foreach (byte d in dadosCriptografados)
                    {
                        sw.WriteLine(d);
                        Console.WriteLine(d);
                    }
                }
            }
            catch (IOException e)
            {
                throw e;
            }
        }
    }
}

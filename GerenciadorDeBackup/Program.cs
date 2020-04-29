using System.IO;
using System;

namespace GerenciadorDeBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            if(Arquivo.TestarArquivo() == true)
            {
                try
                {
                    byte[] dadosOrganizados = Arquivo.LerArquivo();
                    string descriptografado = Criptografia.DecryptStringFromBytes_Aes(dadosOrganizados);
                    string[] partido = descriptografado.Split(',');
                    Backup.FazerBackup(partido);
                    Console.WriteLine("Backup realizado com sucesso!");
                }
                catch (IOException e)
                {

                    Console.WriteLine("Erro: " + e.Message);
                }
                
            }
            else
            {
                Console.Write("Entre com o endereço do servidor: ");
                string servidor = Console.ReadLine();

                Console.Write("Entre com o nome de usuário: ");
                string usuario = Console.ReadLine();

                Console.Write("Entre com a senha para este usuário: ");
                string senha = Console.ReadLine();

                Console.Write("Entre com o nome do banco: ");
                string banco = Console.ReadLine();

                Console.Write("Entre com o caminho de destino do backup: ");
                string caminho = Console.ReadLine();
                

                string final = servidor + "," + usuario + "," + senha + "," + banco + "," + caminho;

                byte[] dadosCriptografados = Criptografia.EncryptStringToBytes_Aes(final);
                try
                {
                    Arquivo.EscreverNoArquivo(dadosCriptografados);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
            }
        }
    }
}

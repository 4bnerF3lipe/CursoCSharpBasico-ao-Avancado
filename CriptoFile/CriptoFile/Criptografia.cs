using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CriptoFile
{
    class Criptografia
    {
        // Declaração de CspParmeters e RsaCryptoServiceProvider
        // Objetos com escopo global na classe.
        public static CspParameters cspp;
        public static RSACryptoServiceProvider rsa;

        // caminhos variáveis para a fonte, pasta de criptografia,
        // e pasta de descriptografia.
        private static string _encrFolder;
        public static string EncrFolder
        {
            get
            {
                return _encrFolder;
            }
            set
            {
                _encrFolder = value;
                PubKeyFile = _encrFolder + "rsaPublicKey.txt";
            }
        }

        public static string DecrFolder { get; set; }
        public static string SrcFolder { get; set; }

        // Arquivo de chave publica
        private static string PubKeyFile = EncrFolder + "rsaPublicKey.txt";

        // Chave contendo o nome para private/public key value pair.
        public static string keyName;

        // Método para criar a chava publica
        public static string CreateAsmKeys()
        {
            string result = "";

            // Armazena uma key pair na key container.
            if (string.IsNullOrEmpty(keyName))
            {
                result = "Chave pública não definida";
                return result;
            }

            cspp.KeyContainerName = keyName;
            rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;
            if (rsa.PublicOnly)
            {
                result = "Key: " + cspp.KeyContainerName + " - Somente Publica";
            }
            else
            {
                result = "Key: " + cspp.KeyContainerName + " - Key Pair Completa";
            }

            return result;
        }

        // Método para Exportar a chave pública a em um arquivo
        public static bool ExportPublicKey()
        {
            bool result = true;

            if (rsa == null)
            {
                return false;
            }

            if (!Directory.Exists(EncrFolder))
            {
                Directory.CreateDirectory(EncrFolder);
            }

            StreamWriter sw = new StreamWriter(PubKeyFile, false);
            try
            {
                sw.Write(rsa.ToXmlString(false));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                sw.Close();
            }

            return result;
        }

        // Método para importar a chave pública de um arquivo
        public static string ImportPublicKey()
        {
            string result = "";

            if (!File.Exists(PubKeyFile))
            {
                result = "Arquivo de chave pública não encontrado.";
                return result;
            }

            if (string.IsNullOrEmpty(keyName))
            {
                result = "Chave pública não definida";
                return result;
            }

            StreamReader sr = new StreamReader(PubKeyFile);

            try
            {
                cspp.KeyContainerName = keyName;
                rsa = new RSACryptoServiceProvider(cspp);
                string keytxt = sr.ReadToEnd();
                rsa.FromXmlString(keytxt);
                rsa.PersistKeyInCsp = true;
                if (rsa.PublicOnly)
                {
                    result = "Key: " + cspp.KeyContainerName + " - Somente Publica";
                }
                else
                {
                    result = "Key: " + cspp.KeyContainerName + " - Key Pair Completa";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }

            return result;
        }

        // Método para criar uma chave privada à partir de um valor deifnido
        public static string GetPrivateKey()
        {
            string result = "";

            if (string.IsNullOrEmpty(keyName))
            {
                result = "Chave privada não definida";
                return result;
            }

            cspp.KeyContainerName = keyName;
            rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;
            
            if (rsa.PublicOnly)
            {
                result = "Key: " + cspp.KeyContainerName + " - Somente Publica";
            }
            else
            {
                result = "Key: " + cspp.KeyContainerName + " - Key Pair Completa";
            }

           return result;
        }

        // Metódo para criptografar um arquivo
        public static string EncryptFile(string inFile)
        {
            // Criar uma instância de Aes para criptografia simétrica dos dados.
            Aes aes = Aes.Create();
            ICryptoTransform transform = aes.CreateEncryptor();

            // Use RSACryptoServiceProvider para
            // criptografar a chave AES.
            // rsa é instanciado anteriormente: rsa = new RSACryptoServiceProvider(cspp);
            
            byte[] keyEncrypted = rsa.Encrypt(aes.Key, false);

            // Crie matrizes de bytes para conter
            // os valores de comprimento da chave e IV.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            int lKey = keyEncrypted.Length;
            LenK = BitConverter.GetBytes(lKey);
            int lIV = aes.IV.Length;
            LenIV = BitConverter.GetBytes(lIV);

            //  Escreva o seguinte no FileStream
            //  para o arquivo criptografado(outFs):
            //  - comprimento da chave
            //  - comprimento do IV
            //  - chave criptografada
            //  - o IV
            //  - o conteúdo da cifra criptografada

            int startFileName = inFile.LastIndexOf("\\") + 1;
            string outFile = EncrFolder + inFile.Substring(startFileName) + ".enc";

            try
            {
                using(FileStream outFs = new FileStream(outFile, FileMode.Create))
                {
                    outFs.Write(LenK, 0, 4);
                    outFs.Write(LenIV, 0, 4);
                    outFs.Write(keyEncrypted, 0, lKey);
                    outFs.Write(aes.IV, 0, lIV);

                    // Agora escreva o texto cifrado usando um CryptoStream para criptografar.
                    using(CryptoStream outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        // Ao criptografar um pedaço por vez, você pode economizar memória.
                        int count = 0;
                        int offset = 0;

                        // blockSizeBytes pode ter qualquer tamanho arbitrário.
                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;

                        using (FileStream inFs = new FileStream(inFile, FileMode.Open))
                        {
                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outStreamEncrypted.Write(data, 0, count);
                                bytesRead += blockSizeBytes;
                            } while (count > 0);
                            inFs.Close();
                        }
                        outStreamEncrypted.FlushFinalBlock();
                        outStreamEncrypted.Close();
                    }
                    outFs.Close();
                    File.Delete(inFile);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return $"Arquivo criptografado.\n Origem: {inFile}\n Destino: {outFile}";
        }

        // Metódo para descriptografar um arquivo
        public static string DecryptFile(string inFile)
        {
            // Criar instância de Aes para descriptografia simétrica dos dados.
            Aes aes = Aes.Create();

            // Crie matrizes de bytes para obter o comprimento da chave criptografada e IV. 
            // Esses valores foram armazenados como 4 bytes cada no início do pacote criptografado.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            // Construir o nome do arquivo para o arquivo descriptografado.
            string outFile = DecrFolder + inFile.Substring(0, inFile.LastIndexOf("."));
            
            try
            {
                // Use objetos FileStream para ler o criptografado (inFs) 
                // e salve o arquivo descriptografado(outFs).
                using (FileStream inFs = new FileStream(EncrFolder + inFile, FileMode.Open))
                {
                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Read(LenK, 0, 3);
                    inFs.Seek(4, SeekOrigin.Begin);
                    inFs.Read(LenIV, 0, 3);

                    // Converta os comprimentos em valores inteiros.
                    int lenK = BitConverter.ToInt32(LenK, 0);
                    int lenIV = BitConverter.ToInt32(LenIV, 0);

                    // Determine a posição inicial do texto cifrado(startC) e seu comprimento(lenS).
                    int startC = lenK + lenIV + 8;
                    int lenC = (int)inFs.Length - startC;

                    // Crie as matrizes de bytes para a chave Aes criptografada, o IV e o texto cifrado.
                    byte[] KeyEncrypted = new byte[lenK];
                    byte[] IV = new byte[lenIV];

                    // Extraia a chave e IV começando do índice 8 após os valores de comprimento.
                    inFs.Seek(8, SeekOrigin.Begin);
                    inFs.Read(KeyEncrypted, 0, lenK);
                    inFs.Seek(8 + lenK, SeekOrigin.Begin);
                    inFs.Read(IV, 0, lenIV);

                    if (!Directory.Exists(DecrFolder))
                    {
                        Directory.CreateDirectory(DecrFolder);
                    }

                    // Use RSACryptoServiceProvider para descriptografar a chave AES.
                    byte[] KeyDecrypted = rsa.Decrypt(KeyEncrypted, false);

                    // Descriptografe a chave.
                    ICryptoTransform transform = aes.CreateDecryptor(KeyDecrypted, IV);

                    // Descriptografar o texto cifrado do FileSteam do arquivo(inFs) criptografado
                    // no FileStream para o arquivo descriptografado(outFs).
                    using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                    {
                        int count = 0;
                        int offset = 0;

                        // blockSizeBytes pode ter qualquer tamanho arbitrário.
                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];

                        // Ao descriptografar um pedaço de cada vez,
                        // você pode economizar memória e acomodar arquivos grandes.

                        // Comece no início do texto cifrado.
                        inFs.Seek(startC, SeekOrigin.Begin);
                        using (CryptoStream outStreamDecrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                        {
                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outStreamDecrypted.Write(data, 0, count);
                            } while (count > 0);

                            outStreamDecrypted.FlushFinalBlock();
                            outStreamDecrypted.Close();
                        }
                        outFs.Close();
                    }
                    inFs.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return $"Arquivo descriptografado.\n Origem: {inFile}\n Destino: {outFile}";
        }
    }
}

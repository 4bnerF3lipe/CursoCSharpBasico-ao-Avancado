using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatCliente
{
    public partial class Form1 : Form
    {
        // Tratar o nome do usuário
        private string NomeUsuario;
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
        private TcpClient tcpServidor;

        // Necessários par aatualizar o formulário com as mensagens da  outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);

        // Necessário para definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress enderecoIP;
        private int portaHost;
        private bool Conectado;

        public Form1()
        {
            // Na saida da aplicação : desconectar
            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            // se não exta conectado aguarde a conexão
            if (!Conectado)
            {
                // Inicializa a conexão
                InicializaConexao();
            }
            else
            {
                // Se esta conectado então desconecta
                FechaConexao("Desconectado a pedido do usuário.");
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviaMensagem();
        }

        private void txtMensagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se precionou a tecla enter
            if (e.KeyChar == (char)13)
            {
                EnviaMensagem();
            }
        }

        private void InicializaConexao()
        {
            try
            {
                // Trata o endereço IP informado em um objeto IPAdress
                enderecoIP = IPAddress.Parse(txtServidorIP.Text);
                // Trata o número da porta do host
                portaHost = (int)numPortaHost.Value;
                // Inicia uma nova conexão TCP com o servidor chat
                tcpServidor = new TcpClient();
                tcpServidor.Connect(enderecoIP, portaHost);

                // Ajuda a verificar se estamos conectados ou não
                Conectado = true;

                // Desabilita e abilita os campos apropriados
                txtServidorIP.Enabled = false;
                numPortaHost.Enabled = false;
                txtUsuario.Enabled = false;
                txtMensagem.Enabled = true;
                btnEnviar.Enabled = true;
                btnConectar.Enabled = true;
                btnConectar.ForeColor = Color.Red;
                btnConectar.Text = "Desconectar";

                // Enviar o nome do usuário para o servidor
                stwEnviador = new StreamWriter(tcpServidor.GetStream());
                stwEnviador.WriteLine(txtUsuario.Text);
                stwEnviador.Flush();

                // Inicializa a thread para receber mensagens e nova comunicação
                mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
                mensagemThread.IsBackground = true;
                mensagemThread.Start();

                labelStatus.Invoke(new Action(() => {
                    labelStatus.ForeColor = Color.Green;
                    labelStatus.Text = $"Conectado ao servidor de Chat {enderecoIP}:{portaHost}";
                }));
            }
            catch (Exception ex)
            {
                labelStatus.Invoke(new Action(()=> {
                    labelStatus.ForeColor = Color.Red;
                    labelStatus.Text = "Erro na conexão com o servidor : \n" + ex.Message;
                }));
            }
        }

        private void RecebeMensagens()
        {
            // Recebe a resposta do servidor
            strReceptor = new StreamReader(tcpServidor.GetStream());
            string ConResposta = strReceptor.ReadLine();

            // Se o primeiro caractere da resposta é 1 a conexão foi feita com sucesso
            if (ConResposta[0] == '1')
            {
                // Atualiza o formulário para informar que esta conectado
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
            }
            else
            {
                // Se o primeiro caractere não for 1 a conexão falhou
                string Motivo = "Não Conectado: ";
                // Extrai o motivo da mensagem resposta. O motivo começa no 3o. caractere
                Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                // Atualiza o formulário com o motivo da falha da conexão
                this.Invoke(new FechaConexaoCallBack(this.AtualizaLog), new object[] { Motivo });
                // Sai do método
                return;
            }

            // Enquanto estiver conectado lê as linhas que estão chegando do servidor
            while (Conectado)
            {
                // Exibe mensagens no TextBox
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });
            }
        }

        private void AtualizaLog(string strMensagem)
        {
            txtLog.AppendText(strMensagem + "\r\n");
        }
        
        private void EnviaMensagem()
        {
            // Enviar a mensagem para o servidor
            if (txtMensagem.Lines.Length >= 1)
            {
                stwEnviador.WriteLine(txtMensagem.Text);
                stwEnviador.Flush();
                txtMensagem.Lines = null;
            }

            txtMensagem.Text = "";
        }

        private void FechaConexao(string Motivo)
        {
            // Fecha a conexão com o servidor
            // Mostra o motivo porque a conexão encerrou
            txtLog.AppendText(Motivo + "\r\n");

            // Desabilita e abilita os campos apropriados
            txtServidorIP.Enabled = true;
            numPortaHost.Enabled = true;
            txtUsuario.Enabled = true;
            txtMensagem.Enabled = false;
            btnEnviar.Enabled = false;
            btnConectar.Enabled = false;
            btnConectar.ForeColor = Color.Green;
            btnConectar.Text = "Conectar";

            // Fechar os objetos
            Conectado = false;
            stwEnviador.Close();
            strReceptor.Close();
            tcpServidor.Close();

            labelStatus.Invoke(new Action(() => {
                labelStatus.ForeColor = Color.Green;
                labelStatus.Text = $"Desconectado do servidor de Chat {enderecoIP}:{portaHost}";
            }));
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Conectado)
            {
                // Fecha as conexões, streams, etc...
                Conectado = false;
                stwEnviador.Close();
                strReceptor.Close();
                tcpServidor.Close();

                labelStatus.Invoke(new Action(() => {
                    labelStatus.ForeColor = Color.Green;
                    labelStatus.Text = $"Desconectado do servidor de Chat {enderecoIP}:{portaHost}";
                }));
            }
        }
    }
}

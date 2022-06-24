using RasReiios.rastrear;
using Function.Ras;
using NVAccess;

namespace WReios;

partial class Form1
{
    string CodigoFile { get; set; }
    System.Windows.Forms.ListBox listBoxRastreios { get; set; }
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private Ras Ras;
    private Ferramentas ferramentas;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 1000);
        this.Text = "WReios";
        this.Ras = new Ras();
        this.ferramentas = new Ferramentas();
        this.CodigoFile = Ras.GetTextFile();
        //adicionando o campo
        System.Windows.Forms.TextBox campoEdic = null;
        if (CodigoFile != null)
        {
            campoEdic = ferramentas.CampoTx(CodigoFile);
        }
        else
        {
            campoEdic = ferramentas.CampoTx();
        }
        this.Controls.Add(campoEdic);

        //botão rastrear
        this.listBoxRastreios = new System.Windows.Forms.ListBox();
        System.Windows.Forms.Button botaoRastrear = ferramentas.CreateButton("Rastrear");
        this.Controls.Add(botaoRastrear);
        botaoRastrear.Click += Button1_Click;

        //botão de salvar em arquivo
        System.Windows.Forms.Button botaoSaveFile = ferramentas.CreateButton("Salvar códigos atuais em um arquivo");
        this.Controls.Add(botaoSaveFile);
        botaoSaveFile.Click += SaveFile_Click;
    }

    private void SaveFile_Click(object sender, EventArgs e)
    {
        //capturar o texto do campo
        var TextFBox = this.Controls.Find("textBox1", true).FirstOrDefault() as System.Windows.Forms.TextBox;
        Ras.saveFile(TextFBox.Text);
        NVDA.Speak("Código salvo em arquivo");
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        NVDA.Speak("Rastreando");

        //capturar o texto do campo
        var TextFBox = this.Controls.Find("textBox1", true).FirstOrDefault() as System.Windows.Forms.TextBox;
        string[] CodigosRastreios;
        //verificar se o texto é multe linhas

        if (TextFBox.Text.Contains("\n"))
        {
            //separar as linhas
            CodigosRastreios = TextFBox.Text.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
        }
        else
        {
            CodigosRastreios = new string[] { TextFBox.Text };
        }

        try
        {
            listBoxRastreios.AccessibleName = "Dados de rastreios";
            //percorrer os códigos de rastreios
            foreach (var CodigoRastreio in CodigosRastreios)
            {
                //rastrear o código
                Rastreando rastrear = new Rastreando(CodigoRastreio);
                var rastrearCr = rastrear.GetInfoRs();

                foreach (var objeto in rastrearCr.objetos)
                {
                    try
                    {
                        listBoxRastreios.Items.Add($"Código: {objeto.codObjeto}\nCategoria: {objeto.tipoPostal.categoria}");

                        foreach (var evento in objeto.eventos)
                        {
                            if (evento.unidadeDestino == null)
                            {
                                string eventosRS = $"{evento.descricao} Em {evento.unidade.tipo}, {evento.unidade.endereco.cidade} {evento.unidade.endereco.bairro} {evento.unidade.endereco.logradouro} {evento.unidade.endereco.numero} {evento.unidade.endereco.uf} {evento.dtHrCriado}";

                                listBoxRastreios.Items.Add(eventosRS);
                            }
                            else
                            {
                                string eventosRS = $"{evento.descricao} Indo para {evento.unidadeDestino.tipo}, {evento.unidadeDestino.endereco.cidade} {evento.unidadeDestino.endereco.uf} {evento.dtHrCriado}";

                                listBoxRastreios.Items.Add(eventosRS);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        listBoxRastreios.Items.Add($"Código: {objeto.codObjeto}\n{objeto.mensagem}");
                    }
                }
            }
            //selecionar o primeiro item por padrão
            listBoxRastreios.SelectedIndex = 0;

            listBoxRastreios.Location = new System.Drawing.Point(200, 200);
            listBoxRastreios.Size = new System.Drawing.Size(100, 100);

            NVDA.Speak("Pronto!");
            ferramentas.PlaySon("sons/complete.wav");

            this.Controls.Add(listBoxRastreios);
            //copiar um item da lista com ctrl+c
            listBoxRastreios.KeyDown += new KeyEventHandler(Ras.CopyItem);
        }
        catch (Exception)
        {
            NVDA.Speak("Não foi possível rastrear, verifique sua conexão", false);
        }
    }

    #endregion
}

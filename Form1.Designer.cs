using RasReiios.rastrear;
using Function.Ras;

namespace WReios;

partial class Form1
{
    string CodigoFile { get; set; }

    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
        Ras Ras = new Ras();
        this.CodigoFile = Ras.GetTextFile();

        //adicionar um campo de edição
        var textBox1 = new System.Windows.Forms.TextBox();
        textBox1.Location = new System.Drawing.Point(12, 12);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(100, 20);
        textBox1.AccessibleName = "Digite o código de rastreio";
        if (CodigoFile != null)
        {
            textBox1.Text = CodigoFile;
        }
        textBox1.TabIndex = 0;
        this.Controls.Add(textBox1);

        //criar um botão
        var button1 = new System.Windows.Forms.Button();
        button1.Text = "Rastrear";
        button1.Location = new System.Drawing.Point(100, 100);
        button1.Size = new System.Drawing.Size(100, 100);
        this.Controls.Add(button1);
        button1.Click += Button1_Click;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        Ras Ras = new Ras();

        //capturar o texto do campo
        var textBox1 = this.Controls.Find("textBox1", true).FirstOrDefault() as System.Windows.Forms.TextBox;
        Rastreando rastrear = new Rastreando(textBox1.Text);
        var rastrearCr = rastrear.GetInfoRs();

        if (CodigoFile != textBox1.Text)
        {
            Ras.saveFile(textBox1.Text);
        }

        var listBoxRastreios = new System.Windows.Forms.ListBox();
        listBoxRastreios.AccessibleName = "Dados rastreios";
        foreach (var objeto in rastrearCr.objetos)
        {
            listBoxRastreios.Items.Add($"Código: {objeto.codObjeto}\nCategoria: {objeto.tipoPostal.categoria}");

            foreach (var evento in objeto.eventos)
            {
                if (evento.unidadeDestino == null)
                {
                    string eventosRS = $"{evento.descricao} Em {evento.unidade.tipo}, {evento.unidade.endereco.cidade} {evento.unidade.endereco.uf} {evento.dtHrCriado}";

                    listBoxRastreios.Items.Add(eventosRS);
                }
                else
                {
                    string eventosRS = $"{evento.descricao} Indo para {evento.unidadeDestino.tipo}, {evento.unidadeDestino.endereco.cidade} {evento.unidadeDestino.endereco.uf} {evento.dtHrCriado}";

                    listBoxRastreios.Items.Add(eventosRS);
                }

            }
        }

        listBoxRastreios.Location = new System.Drawing.Point(200, 200);
        listBoxRastreios.Size = new System.Drawing.Size(100, 100);
        this.Controls.Add(listBoxRastreios);
        //copiar um item da lista com ctrl+c
        listBoxRastreios.KeyDown += new KeyEventHandler(Ras.CopyItem);
    }

    #endregion
}

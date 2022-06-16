namespace WReios;

public class Ferramentas
{

    public System.Windows.Forms.TextBox CampoTx(string? CodigoFile = null)
    {
        //adicionar um campo de edição
        var textBox1 = new System.Windows.Forms.TextBox();
        textBox1.Multiline = true;
        textBox1.Location = new System.Drawing.Point(12, 12);
        textBox1.Text = CodigoFile;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(100, 20);
        textBox1.AccessibleName = "Digite o código de rastreio";
        textBox1.TabIndex = 0;

        return textBox1;
    }

    public System.Windows.Forms.Button CreateButton(string Texto)
    {
        //criar um botão
        var button = new System.Windows.Forms.Button();
        button.Text = Texto;
        button.Location = new System.Drawing.Point(100, 100);
        button.Size = new System.Drawing.Size(100, 100);

        return button;
    }

}

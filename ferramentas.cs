namespace WReios;

public class Ferramentas
{

    public System.Windows.Forms.TextBox CampoTx(string? CodigoFile = null)
    {
        //adicionar um campo de edição
        var textBox = new System.Windows.Forms.TextBox();
        textBox.Multiline = true;
        textBox.Location = new System.Drawing.Point(12, 12);
        textBox.Text = CodigoFile;
        textBox.Name = "textBox1";
        textBox.Size = new System.Drawing.Size(100, 20);
        textBox.AccessibleName = "Digite o código de rastreio";
        textBox.TabIndex = 0;

        return textBox;
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

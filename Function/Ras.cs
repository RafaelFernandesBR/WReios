namespace Function.Ras;

public class Ras
{

    public void CopyItem(object sender, KeyEventArgs e)
    {
        //se precionar ctrl+c
        if (e.KeyCode == Keys.C && e.Control)
        {
            //pegar o item selecionado
            ListBox lista = (ListBox)sender;
            //copiar o item selecionado
            Clipboard.SetText(lista.SelectedItem.ToString());
        }
    }

public void saveFile(string text)
{
    //criar um arquivo
    var file = new System.IO.StreamWriter("Codigo.txt");
    //escrever no arquivo
    file.Write(text);
    //fechar o arquivo
    file.Close();
}

public string GetTextFile()
{
try
{
    //criar um arquivo
    var file = new System.IO.StreamReader("Codigo.txt");
    //ler o arquivo
    string text = file.ReadToEnd();
    //fechar o arquivo
    file.Close();
    //retornar o texto
    return text;
}
catch(Exception ex)
{
    return null;
}
}

}

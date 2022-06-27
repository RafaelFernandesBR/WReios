using RasReiios.rastrear;

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

    public void PlaySon(string audio)
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        player.SoundLocation = audio;
        player.Play();
    }

    public System.Windows.Forms.ListBox CaixaRastreio(string[] CodigosRastreios, ListBox listBoxRastreios)
    {
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

            return listBoxRastreios;
        }
        catch (Exception)
        {
            return null;
        }
    }

}

using System.Globalization;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FileOrganizerDesktop;

public partial class Form1 : Form
{

    private readonly HttpClient _http;
    public Form1()
    {
        InitializeComponent();
        //TODO implement appsettings to register port
        _http = new HttpClient { BaseAddress = new Uri("http://localhost:5888/") };
    }

    private void btnOrigin_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
                txtOrigin.Text = dialog.SelectedPath;
        }
    }

    private void btnDestination_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
                txtDestination.Text = dialog.SelectedPath;
        }
    }

    private async void btnProcess_Click(object sender, EventArgs e)
    {
        lstLog.Items.Clear();

        string inputDir = txtOrigin.Text;
        string outputDir = txtDestination.Text;
        string extension = txtExtension.Text;

        if (!Directory.Exists(inputDir))
        {
            MessageBox.Show("Diretório de origem inválido!");
            return;
        }

        if (string.IsNullOrWhiteSpace(extension))
        {
            MessageBox.Show("Informe a extensão!");
            return;
        }

        btnProcess.Enabled = false;

        try
        {
            var request = new { InputDir = inputDir, OutputDir = outputDir, Extension = extension, Overwrite = true };
            var resp = await _http.PostAsJsonAsync("api/process", request);
            if (!resp.IsSuccessStatusCode)
            {
                var txt = await resp.Content.ReadAsStringAsync();
                MessageBox.Show("Erro do serviço: " + txt);
                return;
            }

            var logs = await resp.Content.ReadFromJsonAsync<string[]>();
            foreach (var l in logs) lstLog.Items.Add(l);

        }
        catch (Exception ex)
        {
            MessageBox.Show("Falha ao conectar ao serviço: " + ex.Message);
        }
        finally
        {
            btnProcess.Enabled = true;
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void btnSelectCleaning_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lblDirCleaning.Text = "Diretório para limpar pastas vazias: " + dialog.SelectedPath;
                lblDirCleaning.Tag = dialog.SelectedPath; // guardamos o valor real
            }
        }
    }

    private async void btnCleanDiretctories_Click(object sender, EventArgs e)
    {
        lstLog.Items.Clear();

        if (lblDirCleaning.Tag == null)
        {
            MessageBox.Show("Selecione primeiro o diretório que deve ser limpo!");
            return;
        }

        string rootDir = lblDirCleaning.Tag.ToString();

        btnCleanDirectories.Enabled = false;

        try
        {
            var request = new { RootPath = rootDir };
            var resp = await _http.PostAsJsonAsync("api/clean", request);
            if (!resp.IsSuccessStatusCode)
            {
                var txt = await resp.Content.ReadAsStringAsync();
                MessageBox.Show("Erro do serviço: " + txt);
                return;
            }
            var result = await resp.Content.ReadFromJsonAsync<CleanResultDTO>();
            foreach (var l in result.Logs) lstLog.Items.Add(l);
            MessageBox.Show($"Concluído. Pastas removidas: {result.Removed}");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Falha ao conectar ao serviço: " + ex.Message);
        }
        finally
        {
            btnCleanDirectories.Enabled = true;
        }
    }

    private record CleanResultDTO(int Removed, string[] Logs);

}

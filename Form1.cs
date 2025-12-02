using System.Globalization;

namespace FileOrganizerDesktop;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
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

    private void btnProcess_Click(object sender, EventArgs e)
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

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        OrganizeFiles(inputDir, outputDir, extension);
    }

    private void OrganizeFiles(string inputDir, string outputDir, string extension)
    {
        var files = GetFilesSafe(inputDir, "*.*");

        foreach (var file in files)
        {
            try
            {
                if (Path.GetExtension(file).Equals(extension, StringComparison.OrdinalIgnoreCase))
                {
                    FileInfo info = new FileInfo(file);

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(file);
                    string fileExtension = info.Extension;

                    DateTime creation = info.LastWriteTime;
                    string creationDate = creation.ToString("dd-MM-yyyy");

                    string newFileName = $"{fileNameWithoutExt}_{creationDate}{fileExtension}";

                    string yearFolder = creation.Year.ToString();
                    string monthFolder = creation.ToString("MMM", new CultureInfo("pt-BR"));

                    string finalFolder = Path.Combine(outputDir, yearFolder, monthFolder);
                    Directory.CreateDirectory(finalFolder);

                    string destinationPath = Path.Combine(finalFolder, newFileName);

                    if (File.Exists(destinationPath))
                    {
                        finalFolder = Path.Combine(finalFolder, "Duplicados");
                        if (!Directory.Exists(finalFolder))
                            Directory.CreateDirectory(finalFolder);
                        destinationPath = Path.Combine(finalFolder, newFileName);
                    }

                    File.Copy(file, destinationPath, true);

                    lstLog.Items.Add($"Copiado: {destinationPath}");

                    File.Delete(file);

                    if (!File.Exists(file))
                        lstLog.Items.Add($"Arquivo {file} deletado do diretório de origem");
                    else
                        lstLog.Items.Add($"Falha ao tentar deletar o arquivo {file} deletado do diretório de origem");
                }
            }
            catch (Exception ex)
            {
                lstLog.Items.Add($"Erro: {ex.Message}");
            }
        }

        MessageBox.Show("Processo concluído!");
    }


    private IEnumerable<string> GetFilesSafe(string path, string filter)
    {
        var files = new List<string>();

        try
        {
            files.AddRange(Directory.GetFiles(path, filter));
        }
        catch
        {
        }

        try
        {
            foreach (var dir in Directory.GetDirectories(path))
            {
                files.AddRange(GetFilesSafe(dir, filter));
            }
        }
        catch
        {
        }

        return files;
    }


    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private int RemoveEmptyDirectories(string dir)
    {
        int removed = 0;

        foreach (var subdir in Directory.GetDirectories(dir))
        {
            removed += RemoveEmptyDirectories(subdir);
        }

        bool whitoutFiles = Directory.GetFiles(dir).Length == 0;
        bool whitoutDirectories = Directory.GetDirectories(dir).Length == 0;

        if (whitoutFiles && whitoutDirectories)
        {
            try
            {
                Directory.Delete(dir);
                lstLog.Items.Add("Pasta removida: " + dir);
                removed++;
            }
            catch (Exception ex)
            {
                lstLog.Items.Add("Erro ao remover: " + dir + " -> " + ex.Message);
            }
        }

        return removed;
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

    private void btnCleanDiretctories_Click(object sender, EventArgs e)
    {
        lstLog.Items.Clear();

        if (lblDirCleaning.Tag == null)
        {
            MessageBox.Show("Selecione primeiro o diretório que deve ser limpo!");
            return;
        }

        string rootDir = lblDirCleaning.Tag.ToString();

        if (!Directory.Exists(rootDir))
        {
            MessageBox.Show("O diretório informado não existe!");
            return;
        }

        int quantityRemoved = RemoveEmptyDirectories(rootDir);

        MessageBox.Show($"Processo concluído!\nPastas vazias excluídas: {quantityRemoved}");
    }


}

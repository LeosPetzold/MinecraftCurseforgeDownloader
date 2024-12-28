using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CurseForge;
using CurseForge.Models.Mods;

namespace CurseforgeManualDownloader
{
    public partial class Form1 : Form
    {
        bool folderSelected = false;
        bool fileSelected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                label1.Text = "Folder selected: " + folderBrowserDialog.SelectedPath;
                folderSelected = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                label2.Text = "File selected: " + openFileDialog.SafeFileName;
                fileSelected = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!folderSelected || !fileSelected) return;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false;

            label3.Text = "Processing...";

            string directory = folderBrowserDialog.SelectedPath;
            string filePath = openFileDialog.FileName;
            string APIkey = textBox1.Text;

            string contents;
            try
            {
                contents = new string(
                    (new System.IO.StreamReader(
                     ZipFile.OpenRead(filePath)
                     .Entries.Where(x => x.Name.Equals("manifest.json", StringComparison.InvariantCulture))
                     .FirstOrDefault()
                     .Open(), Encoding.UTF8)
                     .ReadToEnd())
                     .ToArray());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Couldn't find selected profile file.");
                fileSelected = false;
                button2.Enabled = true;
                return;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Couldn't find manifest.json in profile file.");
                fileSelected = false;
                button2.Enabled = true;
                return;
            }
            ModFile? modFile = JsonSerializer.Deserialize<ModFile>(contents);

            var client = new CurseForge.CurseForge(APIkey);

            if (modFile == null || modFile.files == null)
            {
                Console.WriteLine("modFile or modFile.files is null.");
                return;
            }

            progressBar1.Maximum = progressBar2.Maximum = modFile.files.Count;
            List<Mod> failedMods = TryDownloadFilesInitial(client, modFile.files, directory);

            // Post-processing
            while (true)
            {
                if (failedMods.Count > 0)
                {
                    DialogResult result = MessageBox.Show($"Failed to download {failedMods.Count} mods.\nDo you want to try downloading them again?", "Mod downloading failure", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry)
                    {
                        failedMods = TryDownloadFiles(client, failedMods, directory);
                    }
                    else break;
                }
                else break;
            }
            MessageBox.Show($"Mod downloading complete.\n{modFile.files.Count} mod(s) downloaded.", "Mod downloading done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
        private List<Mod> TryDownloadFilesInitial(CurseForge.CurseForge client, List<Mod> mods, string directory)
        {
            List<Mod> failedMods = new();
            foreach (Mod mod in mods)
            {
                var result = Task.Run(() => TryDownload(client, mod, directory)).Result;
                if (result.success) progressBar1.Increment(1);
                else failedMods.Add(mod);
                label4.Text = result.downloadStatus;
                if (result.errorStatus == string.Empty) label5.Text = result.errorStatus;
                progressBar2.Increment(1);
            }
            return failedMods;
        }
        private List<Mod> TryDownloadFiles(CurseForge.CurseForge client, List<Mod> mods, string directory)
        {
            List<Mod> failedMods = new();
            foreach (Mod mod in mods)
            {
                var result = Task.Run(() => TryDownload(client, mod, directory)).Result;
                if (result.success) progressBar1.Increment(1);
                else failedMods.Add(mod);
                label4.Text = result.downloadStatus;
                if (result.errorStatus == string.Empty) label5.Text = result.errorStatus;
            }
            return failedMods;
        }
        private async Task<TryDownloadFeedback> TryDownload(CurseForge.CurseForge client, Mod mod, string directory)
        {
            CurseForge.Models.CurseResponse<CurseForge.Models.Files.File> modData;
            TryDownloadFeedback feedback = new();
            try
            {
                modData = await client.GetModFile(mod.projectID, mod.fileID);
                feedback.downloadStatus = $"Downloaded {modData.Data.FileName}... ({progressBar2.Value}/{progressBar2.Maximum})";
            }
            catch (HttpRequestException exception)
            {
                feedback.errorStatus = $"Cannot get {mod.projectID}:{mod.fileID} - HTTP error {exception.StatusCode}";
                feedback.success = false;
                return feedback;
            }
            using (var downloader = new HttpClient())
            {
                using var s = downloader.GetStreamAsync(modData.Data.DownloadUrl);
                using var fs = new FileStream(directory + "/" + modData.Data.FileName, FileMode.OpenOrCreate);
                s.Result.CopyTo(fs);
            }
            feedback.success = true;
            return feedback;
        }
    }

    class ModFile
    {
        public Minecraft? minecraft { get; set; }
        public string? manifestType { get; set; }
        public int manifestVersion { get; set; }
        public string? name { get; set; }
        public string? version { get; set; }
        public string? author { get; set; }
        public List<Mod>? files { get; set; }
        public string? overrides { get; set; }
    }

    class Minecraft
    {
        public string? version { get; set; }
        public List<ModLoader>? modLoaders { get; set; }
    }
    class ModLoader
    {
        public string? id { get; set; }
        public bool? primary { get; set; }
    }

    class Mod
    {
        public uint projectID { get; set; }
        public uint fileID { get; set; }
        public bool? required { get; set; }
    }

    class TryDownloadFeedback
    {
        public bool success;
        public string? downloadStatus;
        public string? errorStatus;

        /*public TryDownloadFeedback(bool success, string downloadStatus, string errorStatus)
            => (this.success, this.downloadStatus, this.errorStatus) = (success, downloadStatus, errorStatus);*/
    }
}

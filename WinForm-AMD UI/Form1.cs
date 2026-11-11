using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Работа
{
    public partial class Form1 : Form
    {
        private string selectedModelPath = "";
        private string selectedLoraPath = "";
        private string outputDirectory = @"C:\Users\yoohsy\Desktop\gameimage";

        // Файл для сохранения настроек
        private string configPath = Path.Combine(Application.StartupPath, "settings.ini");

        public Form1()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (File.Exists(configPath))
            {
                var lines = File.ReadAllLines(configPath);
                if (lines.Length > 0 && Directory.Exists(lines[0]))
                {
                    outputDirectory = lines[0];
                }
            }
            lblStatus.Text = "Папка: " + outputDirectory;
        }

        private void SaveSettings()
        {
            try { File.WriteAllLines(configPath, new[] { outputDirectory }); } catch { }
        }

        // Кнопка выбора папки
        private void btnBrowseOutput_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Выберите папку для сохранения картинок";
                fbd.SelectedPath = outputDirectory;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    outputDirectory = fbd.SelectedPath;
                    lblStatus.Text = "Папка: " + outputDirectory;
                    SaveSettings(); // Запоминаем выбор
                }
            }
        }

        // Кнопка выбора модели
        private void btnBrowseModel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Model Files (*.gguf;*.safetensors)|*.gguf;*.safetensors";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedModelPath = ofd.FileName;
                    lblStatus.Text = "Модель выбрана";
                }
            }
        }

        // Кнопка выбора LoRA
        private void btnBrowseLora_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "LoRA Files (*.safetensors)|*.safetensors";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedLoraPath = ofd.FileName;
                    lblStatus.Text = "LoRA выбрана";
                }
            }
        }

        // Кнопка генерации
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedModelPath))
            {
                MessageBox.Show("Сначала выбери модель!");
                return;
            }

            if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, $"gen_{DateTime.Now:HHmmss}.png");

            lblStatus.Text = "Генерация...";
            btnGenerate.Enabled = false;

            string finalPrompt = txtPrompt.Text + ", " + txtPose.Text;
            string loraDirArg = "";

            if (chkUseLora.Checked)
            {
                if (string.IsNullOrEmpty(selectedLoraPath) || !File.Exists(selectedLoraPath))
                {
                    MessageBox.Show("Ты поставил галочку на LoRA, но не выбрал файл!");
                    lblStatus.Text = "Ожидание";
                    btnGenerate.Enabled = true;
                    return;
                }

                string loraName = Path.GetFileNameWithoutExtension(selectedLoraPath);
                loraDirArg = $"--lora-model-dir \"{Path.GetDirectoryName(selectedLoraPath)}\" ";
                finalPrompt += $"<lora:{loraName}:0.75>";
            }

            string args = $"-m \"{selectedModelPath}\" " +
                          $"-p \"{finalPrompt.Replace("\"", "")}\" " +
                          $"-n \"{txtNegative.Text.Replace("\"", "")}\" " +
                          $"-W {numWidth.Value} -H {numHeight.Value} " +
                          $"--steps {numSteps.Value} --cfg-scale {numCfg.Value} --sampling-method dpm++2m --vae-tiling " +
                          $"-s {numSeed.Value} " +
                          $"{loraDirArg}" +
                          $"-o \"{outputPath}\"";

            args = args.Trim();

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = @"C:\Users\yoohsy\Desktop\sd-master-a3f46b6-bin-win-vulkan-x64\sd-cli.exe",
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process { StartInfo = psi };

            process.EnableRaisingEvents = true;
            process.Exited += (s, ev) =>
            {
                this.Invoke(new Action(() =>
                {
                    lblStatus.Text = "Готово";
                    btnGenerate.Enabled = true;
                    if (File.Exists(outputPath))
                    {
                        using (var stream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
                        {
                            picResult.Image = Image.FromStream(stream);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка! Проверь логи.");
                    }
                }));
            };
            MessageBox.Show(args);
            process.Start();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
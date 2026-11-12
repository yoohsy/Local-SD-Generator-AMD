using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Работа // Если ты переименовал проект, поменяй здесь название на свое
{
    public partial class Form1 : Form
    {
        private string selectedModelPath = "";
        private string selectedLoraPath = "";
        private string outputDirectory = "";
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
            lblStatus.Text = string.IsNullOrEmpty(outputDirectory)
                ? "Папка не выбрана"
                : "Папка: " + outputDirectory;
        }

        private void SaveSettings()
        {
            try { File.WriteAllLines(configPath, new[] { outputDirectory }); } catch { }
        }

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
                    SaveSettings();
                }
            }
        }

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
        private void btnBrowseLora_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "LoRA Files (*.safetensors)|*.safetensors";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedLoraPath = ofd.FileName;
                    lblStatus.Text = "LoRA: " + Path.GetFileName(selectedLoraPath); // Показываем, что выбрали
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedModelPath))
            {
                MessageBox.Show("Сначала выбери модель!");
                return;
            }

            if (string.IsNullOrEmpty(outputDirectory))
            {
                MessageBox.Show("Выбери папку для сохранения!");
                return;
            }

            // ПРОВЕРКА: Если галочка стоит, но файл LoRA не выбран
            if (chkUseLora.Checked && string.IsNullOrEmpty(selectedLoraPath))
            {
                MessageBox.Show("Галочка LoRA стоит, но файл не выбран! Нажми кнопку 'Лора' и выбери файл.");
                return;
            }

            if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, $"gen_{DateTime.Now:HHmmss}.png");

            lblStatus.Text = "Генерация...";
            btnGenerate.Enabled = false;

            string finalPrompt = txtPrompt.Text + ", " + txtPose.Text;
            string loraDirArg = "";

            // БЛОК LORA
            if (chkUseLora.Checked)
            {
                string loraName = Path.GetFileNameWithoutExtension(selectedLoraPath);
                loraDirArg = $"--lora-model-dir \"{Path.GetDirectoryName(selectedLoraPath)}\" ";

                string loraWeightStr = numLoraWeight.Value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                // Принудительно добавляем тег
                finalPrompt += $" <lora:{loraName}:{loraWeightStr}>";
            }

            // Если галочка НЕ стоит, но мы хотим проверить, почему тег не добавляется, 
            // можно раскомментировать строку ниже, чтобы увидеть статус галочки:
            // MessageBox.Show("Статус галочки: " + chkUseLora.Checked.ToString());

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
                FileName = Path.Combine(Application.StartupPath, "engine", "sd-cli.exe"),
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

            MessageBox.Show(args); // Оставляем для проверки
            process.Start();
        }

        private void numLoraWeight_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VolWorkbench
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo-white-halloween.ico");
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo-white-halloween.png");

            this.Icon = new Icon(iconPath);
            pictureBox1.Image = Image.FromFile(imagePath);
        }

        public class CommandInfo
        {
            public string Command { get; set; }
            public string Description { get; set; }

            public CommandInfo(string command, string description)
            {
                Command = command;
                Description = description;
            }
        }

        private Process currentProcess = null; // Tiến trình đang chạy
        private bool isProcessing = false; // Trạng thái tiến 

        private void Form1_Load(object sender, EventArgs e)
        {
            button_refresh_process_list.Enabled = false;
            comboBox_command.Enabled = false;
            button_command_info.Enabled = false;
            button_run.Enabled = false;

            // thiết lập DropDownStyle để không cho phép người dùng nhập vào
            comboBox_platform.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_command.DropDownStyle = ComboBoxStyle.DropDownList;

            // danh sách các platform
            string[] platforms = { "windows", "linux", "mac" };
            comboBox_platform.Items.AddRange(platforms);

            // chọn mục đầu tiên mặc định
            if (comboBox_platform.Items.Count > 0)
            {
                comboBox_platform.SelectedIndex = 0;
            }
        }

        private void SetFormState(bool isRunning)
        {
            isProcessing = isRunning;

            // Đổi trạng thái con trỏ chuột
            this.Cursor = isRunning ? Cursors.WaitCursor : Cursors.Default;

            // Kích hoạt / Vô hiệu hóa các nút
            button_refresh_process_list.Enabled = !isRunning;
            comboBox_command.Enabled = !isRunning;
            button_command_info.Enabled = !isRunning;
            //button_run.Enabled = !isRunning;
            //button_about.Enabled = !isRunning;
            //button_exit.Enabled = !isRunning;
            button_clear_log.Enabled = !isRunning;
            button_save_to_file.Enabled = !isRunning;
            button_copy_to_clipboard.Enabled = !isRunning;
            txtpath.Enabled = !isRunning;
            button_browser_image.Enabled = !isRunning;

                
            // Thay đổi button_run thành button_stop nếu đang chạy
            button_run.Text = isRunning ? "Stop" : "Run";
        }

        private void StopCurrentProcess()
        {
            if (currentProcess != null && !currentProcess.HasExited)
            {
                try
                {
                    // Gửi tín hiệu hủy bỏ tiến trình
                    currentProcess.Kill();
                    currentProcess.WaitForExit();
                    richTextBox_log.AppendText("\nProcess has been stopped.\n");
                    button_run.Text = "Run"; // Đổi lại nút thành "Run"
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error stopping process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtpath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpath.Text))
            {
                button_refresh_process_list.Enabled = true; // Kích hoạt nút Refresh
                comboBox_command.Enabled = true;           // Kích hoạt comboBox command
            }
            else
            {
                button_refresh_process_list.Enabled = false;
                comboBox_command.Enabled = false;
            }
        }

        private void button_browser_image_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Memory Dump Files |*.bin;*.raw;*.dump;*.mem|All Files |*.*",
                Title = "Select Image File"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtpath.Text = openFileDialog.FileName;

            }
        }

        private void button_refresh_process_list_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                StopCurrentProcess();
                return;
            }

            string imageFile = txtpath.Text; // đường dẫn file dump
            string platform = comboBox_platform.SelectedItem?.ToString() ?? string.Empty; // platform chọn

            if (string.IsNullOrEmpty(imageFile) || string.IsNullOrEmpty(platform))
            {
                MessageBox.Show("Please select an memory dump file and platform.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // path của thư mục chứa ứng dụng hiện tại
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // path tương đối đến vol.exe
            string volExePath = Path.Combine(appDirectory, "tools", "vol.exe");

            DateTime startTime = DateTime.Now;
            richTextBox_log.AppendText($"[Started at {startTime:yyyy-MM-dd HH:mm:ss}] Starting scan...\n");
            richTextBox_log.AppendText($"\"{volExePath}\" -f \"{imageFile}\" {platform}.pslist\nPlease wait...\n\n");

            if (!File.Exists(volExePath))
            {
                MessageBox.Show($"vol.exe not found at {volExePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // command pslist cho refresh proces lít 
            string command = $"\"{volExePath}\" -f  \"{imageFile}\" {platform}.pslist";

            try
            {
                SetFormState(true); //dua form vao trang thai loading
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command {command}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                currentProcess = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                // đọc output
                currentProcess.OutputDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                    {
                        Invoke(new Action(() =>
                        {
                            richTextBox_log.AppendText($"{ev.Data}\n");
                        }));
                    }
                };

                // đây không phải error mà là nhận phần progress của vol 
                currentProcess.ErrorDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                    {
                        Invoke(new Action(() =>
                        {
                            textBox_progress.Text = $"{ev.Data}\n";

                        }));
                    }
                };

                currentProcess.Exited += (s, ev) =>
                {
                    DateTime endTime = DateTime.Now;
                    Invoke(new Action(() =>
                    {
                        textBox_progress.Clear();
                        richTextBox_log.AppendText($"\n[Finished at {endTime:yyyy-MM-dd HH:mm:ss}] Finished scan...\n");
                        richTextBox_log.AppendText($"\n***********Command finished***********\n");;
                        SetFormState(false); //trang thai bth
                    }));
                };


                // start process
                currentProcess.Start();
                currentProcess.BeginOutputReadLine();
                currentProcess.BeginErrorReadLine();

            }
            catch (Exception ex)
            {
                SetFormState(false);
                MessageBox.Show($"Error while executing command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            if (currentProcess != null && !currentProcess.HasExited)
            {
                // Nếu tiến trình đang chạy, dừng nó
                StopCurrentProcess();
                return;
            }

            string imageFile = txtpath.Text;
            string platform = comboBox_platform.Text;
            string command = comboBox_command.Text;

            if (string.IsNullOrWhiteSpace(imageFile) || string.IsNullOrWhiteSpace(platform) || string.IsNullOrWhiteSpace(command))
            {
                MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực thi lệnh
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string volExePath = Path.Combine(appDirectory, "tools", "vol.exe");

            DateTime startTime = DateTime.Now;
            richTextBox_log.AppendText($"[Started at {startTime:yyyy-MM-dd HH:mm:ss}] Starting scan...\n");
            richTextBox_log.AppendText($"\"{volExePath}\" -f \"{imageFile}\" {command}\nPlease wait...\n\n");

            if (!File.Exists(volExePath))
            {
                MessageBox.Show($"vol.exe not found at {volExePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string commandexc = $"\"{volExePath}\" -f  \"{imageFile}\" {command}";

            try
            {
                SetFormState(true); // Đưa form vào trạng thái loading

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command {commandexc}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                currentProcess = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                currentProcess.OutputDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                    {
                        Invoke(new Action(() =>
                        {
                            richTextBox_log.AppendText($"{ev.Data}\n");
                        }));
                    }
                };

                currentProcess.ErrorDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                    {
                        Invoke(new Action(() =>
                        {
                            textBox_progress.Text = $"{ev.Data}\n";
                        }));
                    }
                };

                currentProcess.Exited += (s, ev) =>
                {
                    DateTime endTime = DateTime.Now;
                    Invoke(new Action(() =>
                    {
                        textBox_progress.Clear();
                        richTextBox_log.AppendText($"\n[Finished at {endTime:yyyy-MM-dd HH:mm:ss}] Finished scan...\n");
                        richTextBox_log.AppendText($"\n***********Command finished***********\n");
                        SetFormState(false); // Đưa form trở lại trạng thái không chạy
                    }));
                };

                currentProcess.Start();
                currentProcess.BeginOutputReadLine();
                currentProcess.BeginErrorReadLine();
                button_run.Text = "Stop";
            }
            catch (Exception ex)
            {
                SetFormState(false); // Đưa form trở lại trạng thái không chạy
                MessageBox.Show($"Error while executing command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<string, List<CommandInfo>> platformCommands = new Dictionary<string, List<CommandInfo>>()
        {
            {
                "windows", new List<CommandInfo>()
                {
                    new CommandInfo("----- Volatility Commands -----", "In order to run a command:\n1- Browse an image file\n2- Get/Refresh process list\n3- Select a command from the list\n4- Enter command parameters\n5- Run command"),
                    new CommandInfo("windows.bigpools.BigPools", "List big page pools"),
                    new CommandInfo("windows.cachedump.Cachedump", "Dumps lsa secrets from memory"),
                    new CommandInfo("windows.callbacks.Callbacks", "Lists kernel callbacks and notification routines"),
                    new CommandInfo("windows.cmdline.CmdLine", "Lists process command line arguments"),
                    new CommandInfo("windows.crashinfo.Crashinfo", "Lists the information from a Windows crash dump"),
                    new CommandInfo("windows.devicetree.DeviceTree", "Listing tree based on drivers and attached devices in a particular windows memory image"),
                    new CommandInfo("windows.dlllist.DllList", "Lists the loaded modules in a particular windows memory image"),
                    new CommandInfo("windows.driverirp.DriverIrp", "List IRPs for drivers in a particular windows memory image."),
                    new CommandInfo("windows.drivermodule.DriverModule", "Determines if any loaded drivers were hidden by a rootkit"),
                    new CommandInfo("windows.driverscan.DriverScan", "Scans for drivers present in a particular windows memory image."),
                    new CommandInfo("windows.dumpfiles.DumpFiles", "Dumps cached file contents from Windows memory samples."),
                    new CommandInfo("windows.envars.Envars", "Display process environment variables"),
                    new CommandInfo("windows.filescan.FileScan", "Scans for file objects present in a particular windows memory image."),
                    new CommandInfo("windows.getservicesids.GetServiceSIDs", "Lists process token sids."),
                    new CommandInfo("windows.getsids.GetSIDs", "Print the SIDs owning each process"),
                    new CommandInfo("windows.handles.Handles", "Lists process open handles."),
                    new CommandInfo("windows.hashdump.Hashdump", "Dumps user hashes from memory"),
                    new CommandInfo("windows.iat.IAT", "Extract Import Address Table to list API (functions) used by a program contained in external libraries"),
                    new CommandInfo("windows.info.Info", "Show OS & kernel details of the memory sample being analyzed."),
                    new CommandInfo("windows.joblinks.JobLinks", "Print process job link information"),
                    new CommandInfo("windows.ldrmodules.LdrModules", "Lists the loaded modules in a particular windows memory image."),
                    new CommandInfo("windows.lsadump.Lsadump", "Dumps lsa secrets from memory"),
                    new CommandInfo("windows.malfind.Malfind", "Lists process memory ranges that potentially contain injected code."),
                    new CommandInfo("windows.mbrscan.MBRScan", "Scans for and parses potential Master Boot Records (MBRs)"),
                    new CommandInfo("windows.memmap.Memmap", "Prints the memory map"),
                    new CommandInfo("windows.mftscan.ADS", "Scans for Alternate Data Stream"),
                    new CommandInfo("windows.mftscan.MFTScan", "Scans for MFT FILE objects present in a particular windows memory image."),
                    new CommandInfo("windows.modscan.ModScan", "Scans for modules present in a particular windows memory image."),
                    new CommandInfo("windows.modules.Modules", "Lists the loaded kernel modules."),
                    new CommandInfo("windows.mutantscan.MutantScan", "Scans for mutexes present in a particular windows memory image."),
                    new CommandInfo("windows.netscan.NetScan", "Scans for network objects present in a particular windows memory image."),
                    new CommandInfo("windows.netstat.NetStat", "Traverses network tracking structures present in a particular windows memory image."),
                    new CommandInfo("windows.poolscanner.PoolScanner", "A generic pool scanner plugin."),
                    new CommandInfo("windows.privileges.Privs", "Lists process token privileges"),
                    new CommandInfo("windows.pslist.PsList", "Lists the processes present in a particular windows memory image."),
                    new CommandInfo("windows.psscan.PsScan", "Scans for processes present in a particular windows memory image."),
                    new CommandInfo("windows.pstree.PsTree", "Plugin for listing processes in a tree based on their parent process ID."),
                    new CommandInfo("windows.registry.certificates.Certificates", "Lists the certificates in the registry's Certificate Store."),
                    new CommandInfo("windows.registry.hivelist.HiveList", "Lists the registry hives present in a particular memory image."),
                    new CommandInfo("windows.registry.hivescan.HiveScan", "Scans for registry hives present in a particular windows memory image."),
                    new CommandInfo("windows.registry.printkey.PrintKey", "Lists the registry keys under a hive or specific key value."),
                    new CommandInfo("windows.registry.userassist.UserAssist", "Print userassist registry keys and information."),
                    new CommandInfo("windows.sessions.Sessions", "lists Processes with Session information extracted from Environmental Variables"),
                    new CommandInfo("windows.skeleton_key_check.Skeleton_Key_Check", "Looks for signs of Skeleton Key malware"),
                    new CommandInfo("windows.ssdt.SSDT", "Lists the system call table."),
                    new CommandInfo("windows.statistics.Statistics", "Lists statistics about the memory space."),
                    new CommandInfo("windows.strings.Strings", "Reads output from the strings command and indicates which process(es) each string belongs to."),
                    new CommandInfo("windows.svcscan.SvcScan", "Scans for windows services."),
                    new CommandInfo("windows.symlinkscan.SymlinkScan", "Scans for links present in a particular windows memory image."),
                    new CommandInfo("windows.thrdscan.ThrdScan", "Scans for windows threads."),
                    new CommandInfo("windows.truecrypt.Passphrase", "TrueCrypt Cached Passphrase Finder"),
                    new CommandInfo("windows.vadinfo.VadInfo", "Lists process memory ranges."),
                    new CommandInfo("windows.vadwalk.VadWalk", "Walk the VAD tree."),
                    new CommandInfo("windows.vadyarascan.VadYaraScan", "Scans all the Virtual Address Descriptor memory maps using yara."),
                    new CommandInfo("windows.verinfo.VerInfo", "Lists version information from PE files."),
                    new CommandInfo("windows.virtmap.VirtMap", "Lists virtual mapped sections.")
                }
            },
            {
                "linux", new List<CommandInfo>()
                {
            // Thêm lệnh Linux tại đây
                    new CommandInfo("----- Volatility Commands -----", "In order to run a command:\n1- Browse an image file\n2- Get/Refresh process list\n3- Select a command from the list\n4- Enter command parameters\n5- Run command"),
                    new CommandInfo("linux.bash.Bash", "Recovers bash command history from memory"),
                    new CommandInfo("linux.capabilities.Capabilities", "Lists process capabilities"),
                    new CommandInfo("linux.check_afinfo.Check_afinfo", "Verifies the operation function pointers of network protocols"),
                    new CommandInfo("linux.check_creds.Check_creds", "Checks if any processes are sharing credential structures"),
                    new CommandInfo("linux.check_idt.Check_idt", "Checks if the IDT has been altered"),
                    new CommandInfo("linux.check_modules.Check_modules", "Compares module list to sysfs info, if available"),
                    new CommandInfo("linux.check_syscall.Check_syscall", "Check system call table for hooks"),
                    new CommandInfo("linux.elfs.Elfs", "Lists all memory mapped ELF files for all processes"),
                    new CommandInfo("linux.envars.Envars", "Lists processes with their environment variables"),
                    new CommandInfo("linux.iomem.IOMem", "Generates an output similar to /proc/iomem on a running system"),
                    new CommandInfo("linux.keyboard_notifiers.Keyboard_notifiers", "Parses the keyboard notifier call chain"),
                    new CommandInfo("linux.kmsg.Kmsg", "Kernel log buffer reader"),
                    new CommandInfo("linux.library_list.LibraryList", "Enumerate libraries loaded into processes"),
                    new CommandInfo("linux.lsmod.Lsmod", "Lists loaded kernel modules"),
                    new CommandInfo("linux.lsof.Lsof", "Lists all memory maps for all processes"),
                    new CommandInfo("linux.malfind.Malfind", "Lists process memory ranges that potentially contain injected code"),
                    new CommandInfo("linux.mountinfo.MountInfo", "Lists mount points on processes mount namespaces"),
                    new CommandInfo("linux.proc.Maps", "Lists all memory maps for all processes"),
                    new CommandInfo("linux.psaux.PsAux", "Lists processes with their command line arguments"),
                    new CommandInfo("linux.pslist.PsList", "Lists the processes present in a particular linux memory image"),
                    new CommandInfo("linux.psscan.PsScan", "Scans for processes present in a particular linux image"),
                    new CommandInfo("linux.pstree.PsTree", "Plugin for listing processes in a tree based on their parent process ID"),
                    new CommandInfo("linux.sockstat.Sockstat", "Lists all network connections for all processes"),
                    new CommandInfo("linux.tty_check.tty_check", "Checks tty devices for hooks"),
                    new CommandInfo("linux.vmayarascan.VmaYaraScan", "Scans all virtual memory areas for tasks using yara")
                }
            },
            {
                "mac", new List<CommandInfo>()
                {
                    new CommandInfo("----- Volatility Commands -----", "In order to run a command:\n1- Browse an image file\n2- Get/Refresh process list\n3- Select a command from the list\n4- Enter command parameters\n5- Run command"),
                    new CommandInfo("mac.bash.Bash", "Recovers bash command history from memory"),
                    new CommandInfo("mac.check_syscall.Check_syscall", "Check system call table for hooks"),
                    new CommandInfo("mac.check_sysctl.Check_sysctl", "Check sysctl handlers for hooks"),
                    new CommandInfo("mac.check_trap_table.Check_trap_table", "Check mach trap table for hooks"),
                    new CommandInfo("mac.dmesg.Dmesg", "Prints the kernel log buffer"),
                    new CommandInfo("mac.ifconfig.Ifconfig", "Lists network interface information for all devices"),
                    new CommandInfo("mac.kauth_listeners.Kauth_listeners", "Lists kauth listeners and their status"),
                    new CommandInfo("mac.kauth_scopes.Kauth_scopes", "Lists kauth scopes and their status"),
                    new CommandInfo("mac.kevents.Kevents", "Lists event handlers registered by processes"),
                    new CommandInfo("mac.list_files.List_Files", "Lists all open file descriptors for all processes"),
                    new CommandInfo("mac.lsmod.Lsmod", "Lists loaded kernel modules"),
                    new CommandInfo("mac.lsof.Lsof", "Lists all open file descriptors for all processes"),
                    new CommandInfo("mac.malfind.Malfind", "Lists process memory ranges that potentially contain injected code"),
                    new CommandInfo("mac.mount.Mount", "A module containing a collection of plugins that produce data typically found in Mac's mount command"),
                    new CommandInfo("mac.netstat.Netstat", "Lists all network connections for all processes"),
                    new CommandInfo("mac.proc_maps.Maps", "Lists process memory ranges that potentially contain injected code"),
                    new CommandInfo("mac.psaux.Psaux", "Recovers program command line arguments"),
                    new CommandInfo("mac.pslist.PsList", "Lists the processes present in a particular mac memory image"),
                    new CommandInfo("mac.pstree.PsTree", "Plugin for listing processes in a tree based on their parent process ID"),
                    new CommandInfo("mac.socket_filters.Socket_filters", "Enumerates kernel socket filters"),
                    new CommandInfo("mac.timers.Timers", "Check for malicious kernel timers"),
                    new CommandInfo("mac.trustedbsd.Trustedbsd", "Checks for malicious trustedbsd modules"),
                    new CommandInfo("mac.vfsevents.VFSevents", "Lists processes that are filtering file system events")
                }
            }
        };

        private void comboBox_platform_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlatform = comboBox_platform.SelectedItem?.ToString() ?? string.Empty;

            // Xóa danh sách cũ trong comboBox_command
            comboBox_command.Items.Clear();

            // Kiểm tra platform có trong danh sách không
            if (platformCommands.ContainsKey(selectedPlatform))
            {
                // Lấy danh sách các lệnh tương ứng với platform đã chọn
                var commands = platformCommands[selectedPlatform];

                // Thêm các lệnh vào comboBox_command
                foreach (var command in commands)
                {
                    // Thêm tên lệnh vào comboBox_command (dùng command.CommandName thay vì CommandInfo đầy đủ)
                    comboBox_command.Items.Add(command.Command);
                }
            }

            // Chọn mục đầu tiên mặc định (nếu có lệnh nào)
            if (comboBox_command.Items.Count > 0)
            {
                comboBox_command.SelectedIndex = 0;
            }
        }

        private void comboBox_command_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy platform đã chọn từ comboBox_platform
            string selectedPlatform = comboBox_platform.SelectedItem?.ToString() ?? string.Empty;

            // Kiểm tra xem có lệnh nào được chọn không
            if (comboBox_command.SelectedItem != null)
            {
                // Lấy tên lệnh đã chọn từ comboBox_command
                string selectedCommandName = comboBox_command.SelectedItem?.ToString() ?? string.Empty;

                // Tìm CommandInfo tương ứng với tên lệnh đã chọn
                CommandInfo selectedCommand = null;

                foreach (var command in platformCommands[selectedPlatform])
                {
                    if (command.Command == selectedCommandName)
                    {
                        selectedCommand = command;
                        break;
                    }
                }

                // Nếu tìm thấy lệnh, hiển thị mô tả trong richTextBox_command_description
                if (selectedCommand != null)
                {
                    richTextBox_command_description.Text = selectedCommand.Description;
                    if (selectedCommand.Command == "----- Volatility Commands -----")
                    {
                        // Nếu lệnh là "----- Volatility Commands -----", vô hiệu hóa các nút
                        button_command_info.Enabled = false;
                        button_run.Enabled = false;
                    }
                    else
                    {
                        // Nếu lệnh khác, kích hoạt các nút
                        button_command_info.Enabled = true;
                        button_run.Enabled = true;
                    }
                }
                else
                {
                    richTextBox_command_description.Text = "Không tìm thấy mô tả cho lệnh này.";
                }
            }
        }

        private void button_clear_log_Click(object sender, EventArgs e)
        {
            richTextBox_log.Clear();
        }

        private void button_save_to_file_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Save Log File"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, richTextBox_log.Text);
                MessageBox.Show("Log saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_copy_to_clipboard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox_log.Text))
            {
                Clipboard.SetText(richTextBox_log.Text);
            }
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Volatility Workbench\nDeveloped by zs0b - 3r0th3r CC", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_command_info_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                StopCurrentProcess();
                return;
            }

            string imageFile = txtpath.Text;
            string platform = comboBox_platform.Text;
            string command = comboBox_command.Text;

            if (string.IsNullOrWhiteSpace(imageFile) || string.IsNullOrWhiteSpace(platform) || string.IsNullOrWhiteSpace(command))
            {
                MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // thực thi lệnh
            // path của thư mục chứa ứng dụng hiện tại
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // path tương đối đến vol.exe
            string volExePath = Path.Combine(appDirectory, "tools", "vol.exe");

            DateTime startTime = DateTime.Now;
            richTextBox_log.AppendText($"[Started at {startTime:yyyy-MM-dd HH:mm:ss}] Starting scan...\n");
            richTextBox_log.AppendText($"\"{volExePath}\" -f \"{imageFile}\" {command} -h\nPlease wait...\n\n");

            if (!File.Exists(volExePath))
            {
                MessageBox.Show($"vol.exe not found at {volExePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // build command cho run
            string commandexc = $"\"{volExePath}\" -f  \"{imageFile}\" {command} -h";

            try
            {
                SetFormState(true);
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command {commandexc}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                currentProcess = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                // đọc output
                currentProcess.OutputDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                    {
                        Invoke(new Action(() =>
                        {
                            richTextBox_log.AppendText($"{ev.Data}\n");
                        }));
                    }
                };

                // đéo phải error, progress 
                currentProcess.ErrorDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                    {
                        Invoke(new Action(() =>
                        {
                            textBox_progress.Text = $"{ev.Data}\n";

                        }));
                    }
                };

                currentProcess.Exited += (s, ev) =>
                {
                    DateTime endTime = DateTime.Now;
                    Invoke(new Action(() =>
                    {
                        textBox_progress.Clear();
                        richTextBox_log.AppendText($"\n[Finished at {endTime:yyyy-MM-dd HH:mm:ss}] Finished scan...\n");
                        richTextBox_log.AppendText($"\n***********Command finished***********\n");
                        SetFormState(false);
                    }));
                };


                //  process
                currentProcess.Start();
                currentProcess.BeginOutputReadLine();
                currentProcess.BeginErrorReadLine();
            }
            catch (Exception ex)
            {
                SetFormState(false);
                MessageBox.Show($"Error while executing command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            StopCurrentProcess();
        }

    }
}

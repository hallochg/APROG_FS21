using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW04_EnviromentKlasse {
    class SystemInformation {

        private string m_current_directory;
        private bool m_is64bit;
        private string m_os_Version;
        private int m_rocessor_count;
        private int m_runtime_min;
        private string m_current_user;
        private int m_thread_id;
        private string m_clr_version;
        private string m_logical_drives;
        private string m_enviroment_var_value;
        private string m_env_var;

        #region
        public string env_var {
            get { return m_env_var; }
            set { m_env_var = value; }
        }
        public string enviroment_var_value {
            get { return m_enviroment_var_value; }
            set { m_enviroment_var_value = value; }
        }


        public string logical_drives {
            get { return m_logical_drives; }
            set { m_logical_drives = value; }
        }


        public string clr_version {
            get { return m_clr_version; }
            set { m_clr_version = value; }
        }


        public int thread_id {
            get { return m_thread_id; }
            set { m_thread_id = value; }
        }


        public string current_user {
            get { return m_current_user; }
            set { m_current_user = value; }
        }


        public int runtime_min {
            get { return m_runtime_min; }
            set { m_runtime_min = value; }
        }


        public int Processor_count {
            get { return m_rocessor_count; }
            set { m_rocessor_count = value; }
        }


        public string os_Version {
            get { return m_os_Version; }
            set { m_os_Version = value; }
        }


        public bool is64bit {
            get { return m_is64bit; }
            set { m_is64bit = value; }
        }

        public string current_directory {
            get { return m_current_directory; }
            set { m_current_directory = value; }
        }
        #endregion

        public SystemInformation() {
            m_current_directory = Environment.CurrentDirectory;
            m_is64bit = Environment.Is64BitProcess;
            m_os_Version = Environment.OSVersion.ToString();
            m_rocessor_count = Environment.ProcessorCount;
            m_runtime_min = Environment.TickCount / 1000 / 60;
            m_current_user = Environment.UserName;
            m_thread_id = Environment.CurrentManagedThreadId;
            m_clr_version = Environment.Version.ToString();
            m_logical_drives = String.Join(" ", Environment.GetLogicalDrives());
            m_env_var = "PROCESSOR_IDENTIFIER";
            m_enviroment_var_value = Environment.GetEnvironmentVariable(m_env_var);
        }
        
    }
}

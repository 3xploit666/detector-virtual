using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace detector_virtual
{
    static class Program
    {
       //3xploit 07 06 2021
        [STAThread]
        static void Main()
        {
            if (MACHINEVIRTUAL())
            {
                MessageBox.Show("maquina detectada saliendo del programa :(");
                Application.Exit();
                return;
            }

            MessageBox.Show("NO DETECTO ENTORNO VIRTUAL SIGUE EN EJECUCION EL RESTO DE CODE ");
        }


        private static bool MACHINEVIRTUAL()
        {
            var searcher = new System.Management.ManagementObjectSearcher("Select Manufacturer,Model from Win32_ComputerSystem");
            var items = searcher.Get();
            foreach (var item in items)
            {
                var manufacturer = item["Manufacturer"].ToString().ToLower();
                if ((manufacturer == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL"))
                    || manufacturer.Contains("vmware")
                    || item["Model"].ToString() == "VirtualBox")
                {
                    return true;
                }
            }

            return false;
        }

    }
}

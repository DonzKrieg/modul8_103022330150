using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static modul8_103022330150.BankTransferConfig;

namespace modul8_103022330150
{
    public class BankTransferConfig
    {
        private const string filePath = "covid_config.json";

        public string lang { get; set; } = "en";
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public Confirmation confirmation { get; set; }

        public class Transfer
        {
            public int threshold { get; set; } = 25000000;
            public int low_fee { get; set; } = 6500;
            public int high_fee { get; set; } = 15000;
        }

        public class Confirmation
        {
            public string en { get; set; } = "yes";
            public string id { get; set; } = "ya";

        }

        public void setDefault()
        {
            BankTransferConfig bank = new BankTransferConfig();
            bank.lang = "en";
            bank.transfer.threshold = 25000000;
            bank.transfer.low_fee = 6500;
            bank.transfer.high_fee = 15000;
            bank.methods = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"];
            bank.confirmation.en = "yes";
            bank.confirmation.id = "ya";
        }

        public BankTransferConfig()
        {
            LoadConfig();
        }

        public BankTransferConfig LoadConfig()
        {
            string configJson = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<BankTransferConfig>(configJson);
            return data;
        }

        private void SimpanConfig()
        {
            string configJson = JsonSerializer.Serialize(LoadConfig);
            File.WriteAllText(filePath, configJson);
        }
    }
    
}

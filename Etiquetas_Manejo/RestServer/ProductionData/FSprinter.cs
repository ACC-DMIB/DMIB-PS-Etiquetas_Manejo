﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
namespace ProductionData
{
    public enum Printer_type
    {
        Spooler,
        Inkjet,
        Undefined
    };

    [DataContract]
    public class FSprinter
    {
        [DataMember(Name = "Disabled", IsRequired = false)]
        public bool Disabled { get; set; }

        [DataMember(Name = "PrinterType", IsRequired = false)]
        public Printer_type PrinterType { get; set; }

        [DataMember(Name = "PrinterLayout", IsRequired = true)]
        public String PrinterLayout { get; set; }

        [DataMember(Name = "PrinterVars", IsRequired = false)]
        public List<FSprinterVars> PrinterVars { get; set; }

        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<FSprinter>));

                using (MemoryStream stream = new MemoryStream())
                {
                    ser.WriteObject(stream, this);
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        stream.Position = 0;
                        ret = sr.ReadToEnd();
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void deserialize(string message)
        {
            try
            {
                if (message == string.Empty)
                    return;

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FSprinter));
                using (Stream ms = new MemoryStream(Encoding.UTF8.GetBytes(message)))
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

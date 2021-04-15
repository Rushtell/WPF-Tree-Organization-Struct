using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Home_Work_11
{
    class JsonDeserializer
    {
        public JsonDeserializer(MainWindow W)
        {
            Start();
        }

        private async void Start()
        {
            string jtext = await File.ReadAllTextAsync(@"CraftA.json");
            var parsedj = JObject.Parse(jtext)["AdminsAndManagers"];

            int i = 0;
            foreach (var ip in parsedj)
            {
                if (parsedj[i]["type"].ToString() == "Manager")
                {
                    DBWorkers.dbManagers.Add(new Manager(
                        parsedj[i]["firstname"].ToString(),
                        parsedj[i]["lastname"].ToString(),
                        (int)parsedj[i]["age"], parsedj[i]["depart"].ToString(),
                        parsedj[i]["mainDepart"].ToString(), (int)parsedj[i]["salary"],
                        (int)parsedj[i]["realSalary"]));
                }
                else
                {
                    DBWorkers.dbManagers.Add(new Administrator(
                        parsedj[i]["firstname"].ToString(),
                        parsedj[i]["lastname"].ToString(),
                        (int)parsedj[i]["age"], parsedj[i]["depart"].ToString(),
                        parsedj[i]["mainDepart"].ToString(), (int)parsedj[i]["salary"],
                        (int)parsedj[i]["realSalary"]));
                }
                i++;
            }

            string jtextW = await File.ReadAllTextAsync(@"CraftW.json");
            var parsedjW = JObject.Parse(jtextW)["WorkersAndInterns"];

            int j = 0;
            foreach (var ip in parsedjW)
            {
                if (parsedjW[j]["type"].ToString() == "Intern")
                {
                    DBWorkers.dbWorkers.Add(new Intern(
                        parsedjW[j]["firstname"].ToString(),
                        parsedjW[j]["lastname"].ToString(),
                        (int)parsedjW[j]["age"],
                        parsedjW[j]["depart"].ToString(),
                        (int)parsedjW[j]["salary"]));
                }
                else
                {
                    DBWorkers.dbWorkers.Add(new Worker(
                        parsedjW[j]["firstname"].ToString(),
                        parsedjW[j]["lastname"].ToString(),
                        (int)parsedjW[j]["age"],
                        parsedjW[j]["depart"].ToString(),
                        (int)parsedjW[j]["salary"]));
                }
                j++;
            }
        }
    }
}

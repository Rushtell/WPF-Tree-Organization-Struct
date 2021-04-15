using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Home_Work_11
{
    class JsonSerializer
    {
        public JsonSerializer()
        {
            Start();
        }

        public async void Start()
        {
            JObject AdminsAndManagers;
            JArray ArrayAdminsAndManagers;
            JObject ConcretAdminOrManager;

            ArrayAdminsAndManagers = new JArray();
            for (int i = 0; i < DBWorkers.dbManagers.Count; i++)
            {
                ConcretAdminOrManager = new JObject();
                ConcretAdminOrManager["firstname"] = DBWorkers.dbManagers[i].firstname;
                ConcretAdminOrManager["lastname"] = DBWorkers.dbManagers[i].lastname;
                ConcretAdminOrManager["age"] = DBWorkers.dbManagers[i].age;
                ConcretAdminOrManager["salary"] = DBWorkers.dbManagers[i].salary;
                ConcretAdminOrManager["depart"] = DBWorkers.dbManagers[i].depart;
                ConcretAdminOrManager["mainDepart"] = DBWorkers.dbManagers[i].mainDepart;
                ConcretAdminOrManager["type"] = DBWorkers.dbManagers[i].type;
                ConcretAdminOrManager["realSalary"] = DBWorkers.dbManagers[i].realSalary;
                ArrayAdminsAndManagers.Add(ConcretAdminOrManager);
            }
            AdminsAndManagers = new JObject();
            AdminsAndManagers["AdminsAndManagers"] = ArrayAdminsAndManagers;

            using (FileStream st = new FileStream(@"CraftA.json", FileMode.OpenOrCreate))
            { }
            await File.WriteAllTextAsync(@"CraftA.json", "");
            await File.WriteAllTextAsync(@"CraftA.json", AdminsAndManagers.ToString());

            ArrayAdminsAndManagers = new JArray();
            for (int i = 0; i < DBWorkers.dbWorkers.Count; i++)
            {
                ConcretAdminOrManager = new JObject();
                ConcretAdminOrManager["firstname"] = DBWorkers.dbWorkers[i].firstname;
                ConcretAdminOrManager["lastname"] = DBWorkers.dbWorkers[i].lastname;
                ConcretAdminOrManager["age"] = DBWorkers.dbWorkers[i].age;
                ConcretAdminOrManager["salary"] = DBWorkers.dbWorkers[i].salary;
                ConcretAdminOrManager["depart"] = DBWorkers.dbWorkers[i].depart;
                ConcretAdminOrManager["type"] = DBWorkers.dbWorkers[i].type;
                ArrayAdminsAndManagers.Add(ConcretAdminOrManager);
            }
            AdminsAndManagers = new JObject();
            AdminsAndManagers["WorkersAndInterns"] = ArrayAdminsAndManagers;

            using (FileStream st = new FileStream(@"CraftW.json", FileMode.OpenOrCreate))
            { }
            await File.WriteAllTextAsync(@"CraftW.json", "");
            await File.WriteAllTextAsync(@"CraftW.json", AdminsAndManagers.ToString());
        }
    }
}
